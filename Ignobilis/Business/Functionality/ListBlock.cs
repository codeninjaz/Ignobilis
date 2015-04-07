using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.SpecializedProperties;
using Ignobilis.Business.Global;
using Ignobilis.Business.Interfaces;
using Ignobilis.Models.Blocks;
using Ignobilis.Models.ViewModels;

namespace Ignobilis.Business.Functionality
{
    public class ListBlock : IListBlock
    {
        public ListBlockViewModel Load(IB_ListBlock currentBlock)
        {
            var itemList = new List<IListItem>();

            if (currentBlock.ListContentTree != null)
            {
                GetItems(Strings.ListContentTree, currentBlock.ListContentTree, ref itemList);
            }

            if (currentBlock.LinkList != null)
            {
                GetItems(Strings.LinkList, currentBlock.LinkList, ref itemList);
            }

            if (currentBlock.ExternalList != null)
            {
                GetItems(Strings.ExternalList, currentBlock.ExternalList, ref itemList);
            }

            itemList = itemList.Distinct(new ListItemEqualityComparer()).ToList();

            SortList(currentBlock, ref itemList);

            if (currentBlock.NumberPerPage > 0)
            {
                itemList = itemList.Take(currentBlock.NumberPerPage).ToList();
            }

            return new ListBlockViewModel { Items = itemList, Layout = currentBlock.Layout };
        }

        private static void GetItems(string type, LinkItemCollection collection, ref List<IListItem> itemList)
        {
            Type listType;
            if (IgnobilisService.Instance.Settings.Functionality.ContentLists.TryGetValue(type, out listType))
            {
                var instance = (IList)Activator.CreateInstance(listType);
                instance.Init(collection);
                itemList.AddRange(instance.Items);
            }
        }

        private static void SortList(IB_ListBlock currentBlock, ref List<IListItem> itemList)
        {
            if (currentBlock.SortMode == Strings.SortModeTitle)
            {
                if (currentBlock.Sorting == Strings.SortingAsc)
                {
                    itemList.Sort((item, listItem) => String.Compare(item.Title, listItem.Title, StringComparison.Ordinal));
                }
                else if (currentBlock.Sorting == Strings.SortingDesc)
                {
                    itemList.Sort((item, listItem) => String.Compare(listItem.Title, item.Title, StringComparison.Ordinal));
                }
            }
            else if (currentBlock.SortMode == Strings.SortModeDate)
            {
                if (currentBlock.Sorting == Strings.SortingAsc)
                {
                    itemList.Sort((item, listItem) => DateTime.Compare(item.PublishedDate, listItem.PublishedDate));
                }
                else if (currentBlock.Sorting == Strings.SortingDesc)
                {
                    itemList.Sort((item, listItem) => DateTime.Compare(listItem.PublishedDate, item.PublishedDate));
                }
            }
        }
    }
}