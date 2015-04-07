using System;
using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.SpecializedProperties;
using Ignobilis.Business.Interfaces;
using Ignobilis.Models.Data;

namespace Ignobilis.Business.Functionality
{
    public class LinkList : IList
    {
        public LinkList()
        {
            Items = new List<IListItem>();
        }

        public List<IListItem> Items { get; set; }

        public bool Init(LinkItemCollection linkCollection)
        {
            var pdList = linkCollection.ToPages();
            var enumerable = FilterForVisitor.Filter(pdList);

            foreach (var child in enumerable)
            {
                Items.Add(new PageDataItem((PageData)child));
            }

            return Items.Count != 0;
        }

    }
}