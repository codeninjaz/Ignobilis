using System;
using System.Net;
using System.Text;
using System.Web;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Ignobilis.Business.Interfaces;
using Ignobilis.Models.Pages;

namespace Ignobilis.Models.Data
{
    public class PageDataItem : IListItem
    {
        public PageDataItem(PageData child)
        {
            var ibBasePage = child as IB_OrdinaryPage;
            if (ibBasePage != null)
            {
                Description = ibBasePage.Ingress;
            }
            else
            {
                var propertyValue = child.GetPropertyValue("MainBody");
               
                if (propertyValue != null)
                {
                    var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                    htmlDoc.LoadHtml(propertyValue);
                    var node = htmlDoc.DocumentNode.SelectSingleNode("//p");

                    if (node != null)
                    {
                        if (node.InnerText.Length > 400)
                        {
                            Description = node.InnerText.Substring(0, 400) + " ...";
                        }
                        else
                        {
                            Description = node.InnerText;
                        }
                    }
                }
            }

            Title = child.PageName;

            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            var url = urlResolver.GetVirtualPath(child.ContentLink).GetUrl();

            Id = child.ContentGuid;
            Link = url;
            PublishedDate = child.StartPublish;
            IsExternal = false;

        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Url Link { get; set; }
        public string LinkText { get; set; }
        public Url Image { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsExternal { get; set; }
    }
}