using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.SpecializedProperties;
using EPiServer.Web.Routing;

namespace Ignobilis.Business
{
    public static class Util
    {
        public static List<PageData> ToPages(this LinkItemCollection linkItemCollection)
        {
            var pages = new List<PageData>();

            //TODO: Va? ska det verkligen vara såhär?
            foreach (var linkItem in linkItemCollection)
            {
                var permanentLink = linkItem.ToPermanentLink();

                if (permanentLink.Contains("~/link") && permanentLink.Contains(".aspx"))
                {
                    var link = permanentLink.Substring(permanentLink.IndexOf("~/link", StringComparison.Ordinal) + 7);                    
                    var indexOfAspx = link.IndexOf(".aspx", StringComparison.Ordinal);

                    if (indexOfAspx != -1) {
                        var substring = link.Substring(0, indexOfAspx);
                        var guid = Guid.Parse(substring);

                        var pageData = ServiceLocator.Current.GetInstance<IContentRepository>().Get<PageData>(guid);


                        pages.Add(pageData);
                    }
                }

            }

            return pages;
        }

        public static String Url(this PageReference pageReference)
        {
            var pd = ServiceLocator.Current.GetInstance<IContentRepository>().Get<PageData>(pageReference);
            var url = new UrlBuilder(pd.LinkURL);
            EPiServer.Global.UrlRewriteProvider.ConvertToExternal(url, pd.PageLink, Encoding.UTF8);
            return url.ToString();   
        }

        public static String AssemblyVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var ver = assembly.GetName().Version;

            return ver.ToString();
        }

        public enum MessageType
        {
            Emergency,
            Warning,
            Error,
            Information,
            Default
        }

        public enum ContentType
        {
            Rss, Default
        }

        public static ContentType GetContent(string contentType)
        {
            var c = contentType.ToLower();
            if (c == "text/xml" || c == "application/rss+xml" || c == "application/xml")
            {
                return ContentType.Rss;
            }

            return ContentType.Default;
        }
    }
}