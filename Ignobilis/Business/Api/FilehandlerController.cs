using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using EPiServer;
using EPiServer.Core;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Ignobilis.Business.Extensions;
using Lantm.Services;

namespace Ignobilis.Business.Api
{
    [RoutePrefix("api/filehandler")]
    public class FilehandlerApiController : ApiController
    {
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        // GET api/<controller>
        [Route("filedata")]
        [HttpPost]
        public FileTreeInfo Get([FromBody]dynamic info)
        {
            var context = HttpContext.Current;
            var files = Load(context, info.path.ToString());
            return files;
        }

        private string GetFilePath(ContentReference reference, string path)
        {
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            string url = urlResolver.GetUrl(reference);
            return url;
        }

        public List<MediaData> GetFiles(ContentFolder cf)
        {
            try
            {
                var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
                var contentFolder = contentRepository.Get<ContentFolder>(cf.ContentLink);
                return contentRepository.GetChildren<MediaData>(contentFolder.ContentLink) == null
                    ? new List<MediaData>()
                    : contentRepository.GetChildren<MediaData>(contentFolder.ContentLink).ToList();
            }
            catch
            {
                return new List<MediaData>();
            }
        }
        private string GetFileType(string p)
        {
            if (p.EndsWith("/pdf"))
                return "pdf";
            if (p.EndsWith(".ms-excel") || p.Contains("spreadsheet"))
                return "xlsx";
            if (p.EndsWith("/msword"))
                return "doc";
            if (p.EndsWith("/jpeg"))
                return "jpg";
            if (p.EndsWith("/gif"))
                return "gif";
            if (p.EndsWith("/png"))
                return "png";
            if (p.EndsWith(".ms-powerpoint") || p.EndsWith(".presentation"))
                return "ppt";
            return "";
        }
        
        private string GetLink(MediaData file)
        {
            using (var stream = file.BinaryData.OpenRead())
            {
                var reader = new StreamReader(stream);
                var ret = "";
                while (!reader.EndOfStream)
                {
                    ret = reader.ReadLine();
                }
                if (ret == null) return "";
                reader.Close();
                if (ret.IsFilePath())
                {
                    try
                    {
                        var url = new UriBuilder("file://" + ret);
                        if (ret.IndexOf(":", StringComparison.Ordinal) > 0)
                        {
                            url = new UriBuilder("file:///" + ret);
                        }
                        ret = url.ToString();
                        return ret;
                    }
                    catch (Exception exc)
                    {
                        ret = exc.Message;
                    }
                }
                return ret.IsURL() ? new UriBuilder(ret).ToString() : "";
            }
        }

        /// <summary>
        ///     Hämta namnet på länken från namnet på länkfilen.
        /// </summary>
        /// <param name="name">Namnet på länkfilen.</param>
        /// <returns>Namnet på en länken utan __lnk och suffix</returns>
        private string GetLinkName(string name)
        {
            return Regex.Replace(name, "__lnk.*", "", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
        }

        private string getRightsJson(ContentFolder dir, AccessLevel level)
        {
            var right = dir.QueryDistinctAccess(level);
            return string.Format("{0}", right ? '1' : '0');
            //return string.Format("{{\"read\",\"{0}\"}}, {{\"del\",\"{1}\"}}, {{\"move\",\"{2}\"}}", read, del, move);
        }

        /// <summary>
        /// Ladda alla noder med data från filstrukturen
        /// </summary>
        /// <param name="context">Den HttpContext appen körs i</param>
        /// <param name="dirId">GUID för rotkatalogen</param>
        private FileTreeInfo Load(HttpContext context, string dirId)
        {
            //Hämta epi användare.
            var username = context.User.Identity.Name;
            var epiUser = PrincipalInfo.CreatePrincipal(username);
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var folder = contentRepository.Get<ContentFolder>(ContentReference.Parse(dirId));

            var rootNode = new FileTreeInfo
            {
                id = "root",
                parentId = "",
                name = "roten",
                size = 0,
                link = "",
                type = "root",
                children = new List<FileTreeInfo>()
                
                //folder = true,
                //folderPath = "",
                //key = "0",
                //path = "",
                //title = "rooten",
            };

            var includedRootNode = new FileTreeInfo
            {
                id = dirId.ToString(CultureInfo.InvariantCulture),
                type = "dir",
                name = folder.Name,
                parentId = rootNode.id,
                size = 0,
                link = folder.Name,
                children = new List<FileTreeInfo>()
                
                //key = dirId.ToString(CultureInfo.InvariantCulture),
                //folder = true,
                //title = folder.Name,
                //path = folder.Name,
                //folderPath = folder.Name + "/",
                //edit = getRightsJson(folder, AccessLevel.Edit),
                //delete = getRightsJson(folder, AccessLevel.Delete),
                //contentreference = folder.ContentLink.ToString(),
                //typeofmedia = "folder",
            };
            rootNode.children.Add(includedRootNode);
            LoadRecursiveFromMedia(folder, includedRootNode, epiUser, dirId);
            return rootNode;
        }

        public void LoadRecursiveFromMedia(ContentFolder rootDir, FileTreeInfo theNode, IPrincipal epiUser,
            string rootreference)
        {
            if (theNode == null) throw new ArgumentNullException("theNode");
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var rootFolder = contentRepository.Get<ContentFolder>(ContentReference.Parse(rootreference));

            //Get directories
            var dirs = FileManagement.GetFolders(contentRepository, rootDir);
            var contentFolders = dirs as ContentFolder[] ?? dirs.ToArray();
            if (contentFolders.Any())
            {
                foreach (var dir in contentFolders)
                {
                    var path = rootFolder.Name == rootDir.Name
                        ? rootFolder.Name + "/"
                        : rootFolder.Name + "/" + rootDir.Name + "/";
                    var node = new FileTreeInfo
                    {
                        id = dir.ContentLink.ID.ToString(CultureInfo.InvariantCulture),
                        link = path,
                        name = dir.Name,
                        size = 0,
                        parentId = rootDir.ContentLink.ID.ToString(CultureInfo.InvariantCulture),
                        type = "dir",
                        children = new List<FileTreeInfo>()

                        //key = dir.ContentLink.ID.ToString(CultureInfo.InvariantCulture),
                        //folder = true,
                        //title = dir.Name,
                        //path = path,
                        //folderPath = rootFolder.Name + "/",
                        //edit = getRightsJson(dir, AccessLevel.Edit),
                        //delete = getRightsJson(dir, AccessLevel.Delete),
                        //contentreference = dir.ContentLink.ToString(),
                        //typeofmedia = "folder",
                        //children = new List<TreeNode>()
                    };

                    if (dir.QueryDistinctAccess(AccessLevel.Read))
                    {
                        theNode.children.Add(node);
                    }
                    LoadRecursiveFromMedia(dir, node, epiUser, rootreference);
                }
            }

            //Get files if epiUser has access
            //TODO: Hantera rättigheter om man får redigera, deleta. Anders Sjöberg 2015-05-12 10:38
            if (rootDir.QueryDistinctAccess(AccessLevel.Read))
            {
                var files = GetFiles(rootDir);
                if (files.Any())
                {
                    var path = rootFolder.Name == rootDir.Name
                        ? rootFolder.Name + "/"
                        : rootFolder.Name + "/" + rootDir.Name + "/";
                    theNode.children.AddRange(files.Select(media => new FileTreeInfo
                    {
                        id=media.ContentLink.ID.ToString(CultureInfo.InvariantCulture),
                        type = GetFileType(media.MimeType),
                        name = FileManagement.IsLinkNode(media) ? GetLinkName(media.Name) : media.Name,
                        link = FileManagement.IsLinkNode(media) ? GetLink(media) : "",
                        parentId = theNode.id,
                        size = 1,
                        path = GetFilePath(media.ContentLink, media.Name),
                        children = new List<FileTreeInfo>()
                        //key = media.ContentLink.ID.ToString(CultureInfo.InvariantCulture),
                        //folder = false,
                        //title = FileManagement.IsLinkNode(media) ? GetLinkName(media.Name) : media.Name,
                        //path = GetFilePath(media.ContentLink, media.Name),
                        //folderPath = path,
                        //edit = getRightsJson(rootDir, AccessLevel.Edit),
                        //delete = getRightsJson(rootDir, AccessLevel.Delete),
                        //link = FileManagement.IsLinkNode(media) ? GetLink(media) : "", //GetFilePath(uFile.ContentLink, uFile.Name), 
                        //icon = FileManagement.IsLinkNode(media) ? "/images/link.png" : GetKnowIcon(media.MimeType),
                        //typeofmedia = "file",
                        //contentreference = media.ContentLink.ToString(),
                        //children = new List<TreeNode>()
                    }).ToList());
                }
            }
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }
    }

    /*
                             key = media.ContentLink.ID.ToString(CultureInfo.InvariantCulture),
                        folder = false,
                        title = FileManagement.IsLinkNode(media) ? GetLinkName(media.Name) : media.Name,
                        path = GetFilePath(media.ContentLink, media.Name),
                        folderPath = path,
                        edit = getRightsJson(rootDir, AccessLevel.Edit),
                        delete = getRightsJson(rootDir, AccessLevel.Delete),
                        link = FileManagement.IsLinkNode(media) ? GetLink(media) : "",
                        //GetFilePath(uFile.ContentLink, uFile.Name), 
                        icon = FileManagement.IsLinkNode(media) ? "/images/link.png" : GetKnowIcon(media.MimeType),
                        typeofmedia = "file",
                        contentreference = media.ContentLink.ToString(),
                        children = new List<TreeNode>()
     */

    public class FileTreeInfo
    {
        // ReSharper disable InconsistentNaming
        public string name { get; set; }
        public string id { get; set; }
        public string parentId { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public long size { get; set; }
        public string path { get; set; }
        public List<FileTreeInfo> children { get; set; }
        // ReSharper restore InconsistentNaming
    }
}

/* Struktur på datat
{
    "name": "a",
    "id": 1,
    "parentId": "",
    "type": "dir",
    "children": [
        {
            "name": "as",
            "id": "631cc69a-2eb6-4cb6-a1a8-23b40d3b2429",
            "parentId": 1,
            "type": "dir",
            "link": "http://you.a",
            "size": 0,
            "children": [
                {
*/