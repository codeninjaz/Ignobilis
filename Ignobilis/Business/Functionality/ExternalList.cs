using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;
using EPiServer.DataAbstraction;
using EPiServer.SpecializedProperties;
using Ignobilis.Business.Interfaces;
using Ignobilis.Models.Data;

namespace Ignobilis.Business.Functionality
{
    public class ExternalList : IList
    {
        public ExternalList()
        {
            Items = new List<IListItem>();
        }

        public List<IListItem> Items { get; set; }

        public bool Init(LinkItemCollection linkCollection)
        {
            foreach (var linkItem in linkCollection)
            {                
                var uriBuilder = new UriBuilder(linkItem.Href);
                var httpWebRequest = WebRequest.CreateHttp(uriBuilder.Uri);

                using (var response = httpWebRequest.GetResponse())
                {                    
                    using (var stream = response.GetResponseStream())
                    {
                        var contentType = Util.GetContent(response.ContentType);

                        switch (contentType)
                        {
                            case Util.ContentType.Rss:
                                if (stream != null)
                                {
                                    var r = XmlReader.Create(stream);
                                    var feed = SyndicationFeed.Load(r);
                                    r.Close();

                                    if (feed != null)
                                        foreach (var item in feed.Items)
                                        {
                                            Items.Add(new RssDataItem(item));
                                        }
                                }
                                break;
                            default:
                                break;
                        }

                    }
                }
            }


            return true;
        }


    }
}