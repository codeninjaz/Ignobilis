using System.Collections.Generic;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
using EPiServer.SpecializedProperties;
using Ignobilis.Business.Interfaces;
using Ignobilis.Models.Data;

namespace Ignobilis.Business.Functionality
{
    public class ListContentTree : IList
    {
        public ListContentTree()
        {
            Items = new List<IListItem>();
        }

        public List<IListItem> Items { get; set; }

        public bool Init(LinkItemCollection linkCollection)
        {
            var pdList = new List<PageData>();
            foreach (var pages in linkCollection.ToPages())
            {                
                pdList.AddRange(ServiceLocator.Current.GetInstance<IContentRepository>().GetChildren<PageData>(pages.PageLink));
            }

            var enumerable = FilterForVisitor.Filter(pdList);

            foreach (var child in enumerable)
            {
                Items.Add(new PageDataItem((PageData)child));
            }

            return Items.Count != 0;
        }

    }
}