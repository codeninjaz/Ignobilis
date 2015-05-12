using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Web;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Web.Hosting;
using Newtonsoft.Json;

namespace Lantm.Services
{
    public class FileManagement
    {
        public static IEnumerable<ContentFolder> GetFolders(IContentRepository contentRepository, ContentFolder folder)
        {
            var subFolders = contentRepository.GetChildren<ContentFolder>(folder.ContentLink);
            return subFolders;
        }

        /// <summary>
        /// Kollar om noden man angett är en länk nod.
        /// </summary>
        /// <param name="node">Nod som ska kontrolleras</param>
        /// <returns>True om noden är en länknod, annars false</returns>
        public static bool IsLinkNode(UnifiedFile node)
        {
            return node.Name != null && node.Name.IndexOf("__lnk", StringComparison.Ordinal) > 0;
        }

        public static bool IsLinkNode(MediaData node)
        {
            return node.Name != null && node.Name.IndexOf("__lnk", StringComparison.Ordinal) > 0;
        }

        /// <summary>
        /// Flytta fil eller katalog
        /// </summary>
        /// <param name="context">HttpContext som appen körs i</param>
        /// <param name="moveFrom">Sökväg att flytta från</param>
        /// <param name="moveTo">Sökväg att flytta till</param>
        public static void Move(HttpContext context, string moveFrom, string moveTo)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var from = contentRepository.Get<IContentData>(ContentReference.Parse(moveFrom));
            var to = contentRepository.Get<IContentData>(ContentReference.Parse(moveTo));
            if (@from.GetOriginalType() == typeof(ContentFolder))
            {
                var media = ((ContentFolder)@from).CreateWritableClone();
                if (to.GetOriginalType() == typeof(ContentFolder))
                {
                    var key = contentRepository.Move(media.ContentLink, ((ContentFolder)to).ContentLink, AccessLevel.Edit, AccessLevel.Edit);
                    SendOkMessage(context, new { status = "success", newKey = key.ID.ToString(CultureInfo.InvariantCulture) });
                }
                else
                {
                    var key = contentRepository.Move(media.ContentLink, ((MediaData)to).ParentLink, AccessLevel.Edit, AccessLevel.Edit);
                    SendOkMessage(context, new { status = "success", newKey = key.ID.ToString(CultureInfo.InvariantCulture) });
                }
            }
            else
            {
                var media = ((MediaData)@from).CreateWritableClone();
                if (to.GetOriginalType() == typeof(ContentFolder))
                {
                    var key = contentRepository.Move(((MediaData)media).ContentLink, ((ContentFolder)to).ContentLink, AccessLevel.Edit, AccessLevel.Edit);
                    SendOkMessage(context, new { status = "success", newKey = key.ID.ToString(CultureInfo.InvariantCulture) });
                }
                else
                {
                    var key = contentRepository.Move(((MediaData)media).ContentLink, ((MediaData)to).ParentLink, AccessLevel.Edit, AccessLevel.Edit);
                    SendOkMessage(context, new { status = "success", newKey = key.ID.ToString(CultureInfo.InvariantCulture) });
                }
            }
        }

        /// <summary>
        /// Byt namn på fil eller mapp
        /// </summary>
        /// <param name="context">HttpContext som appen körs i</param>
        public static void Rename(HttpContext context)
        {
            var newname = context.Request["newname"];
            var contentref = context.Request["contentreference"];
            var typeofmedia = context.Request["typeofmedia"];

            if (String.IsNullOrEmpty(contentref) || String.IsNullOrEmpty(newname))
            {
                SendError(context, "oldname or newname not provided");
                return;
            }
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            //todo - verify link
            //newname = newname.Replace("__lnk.txt", "");
            if (typeofmedia == "folder")
            {
                var folder = contentRepository.Get<ContentFolder>(ContentReference.Parse(contentref));
                if (folder.QueryDistinctAccess(AccessLevel.Edit))
                { 
                    var f = folder.CreateWritableClone();
                    f.Name = newname;
                    contentRepository.Save(f,SaveAction.Publish,AccessLevel.Edit);
                    SendOkMessage(context, new { status = "success", newKey = folder.ContentLink.ID.ToString(CultureInfo.InvariantCulture) });
                }
                else
                {
                    SendError(context, "Du har inte behörighet att döpa om katalogen. Redigeringsrättigheter krävs");
                    return;
                }
            }
            else 
            {
                var media = contentRepository.Get<MediaData>(ContentReference.Parse(contentref));
                if (media.QueryDistinctAccess(AccessLevel.Edit))
                {
                    var m = media.CreateWritableClone() as MediaData;
                    m.Name = newname;
                    contentRepository.Save(m, SaveAction.Publish, AccessLevel.Edit);
                    SendOkMessage(context, new { status = "success", newKey = media.ContentLink.ID.ToString(CultureInfo.InvariantCulture) });
                }
                else
                {
                    SendError(context, "Du har inte behörighet att döpa om filen. Redigeringsrättigheter krävs");
                    return;
                }
            }
        }

        /// <summary>
        /// Returnera ett felmeddelande till klienten
        /// </summary>
        /// <param name="context">HttpContext som appen körs i</param>
        /// <param name="message">Meddelande att skicka</param>
        public static void SendError(HttpContext context, string message)
        {
            context.Response.TrySkipIisCustomErrors = true;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.Write(JsonConvert.SerializeObject(new { status = "fail", statusMessage = message }));
            context.Response.Flush();
        }

        /// <summary>
        /// Skicka ett "success" meddelande till klienten
        /// </summary>
        /// <param name="context">HttpContext som appen körs i</param>
        /// <param name="message">Meddelande som ska skickas</param>
        public static void SendOkMessage(HttpContext context, string message)
        {
            context.Response.StatusCode = 200;
            context.Response.Write(JsonConvert.SerializeObject(new { status = "success", statusMessage = message }));
            context.Response.Flush();
        }

        /// <summary>
        /// Skicka ett "success" meddelande till klienten
        /// </summary>
        /// <param name="context">HttpContext som appen körs i</param>
        /// <param name="obj">Objekt med data som ska skickas till klienten via JSON</param>
        public static void SendOkMessage(HttpContext context, object obj)
        {
            context.Response.StatusCode = 200;
            context.Response.Write(JsonConvert.SerializeObject(obj));
            context.Response.Flush();
        }
    }
}