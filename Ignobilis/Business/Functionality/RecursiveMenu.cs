using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using Ignobilis.Business.Interfaces;

namespace Ignobilis.Business.Functionality
{
    public class RecursiveMenu : IRecursiveMenu
    {
        public PageData PageData { get; set; }
        public int Level { get; set; }
        public List<IRecursiveMenu> Load(PageReference start, PageReference activePage, int currentLevel = 0)
        {
            if(start == null || start == PageReference.EmptyReference) return new List<IRecursiveMenu>();

            var pageDataCollection = ServiceLocator.Current.GetInstance<IContentRepository>().GetChildren<PageData>(start);

            var recursiveMenus = new List<IRecursiveMenu>();
            foreach (var item in pageDataCollection)
            {
                //todo: lägg till filtrering för användare
                if (!item.VisibleInMenu) continue;

                //Om det är den aktuella sidan som ligger med i trädet
                ActivePage = activePage == item.PageLink;

                var tempItem = item;
                var ancestors = ServiceLocator.Current.GetInstance<IContentRepository>()
                    .GetAncestors(activePage).Where(x =>
                                                {
                                                    var pageData = x as PageData;
                                                    return pageData != null && pageData.PageLink == tempItem.PageLink;
                                                }).ToList();

                HaveChildren = ServiceLocator.Current.GetInstance<IContentRepository>().GetChildren<PageData>(item.PageLink).Any();
                
                IsInChain = ancestors.Any() || ActivePage;
                PageData = item;
                
                recursiveMenus.Add(new RecursiveMenu
                                    {
                                        PageData = item,
                                        ActivePage = ActivePage,
                                        HaveChildren = HaveChildren,
                                        IsInChain = IsInChain,
                                        Level = currentLevel
                                    });
            }

            var menu = new List<IRecursiveMenu>();
            menu.AddRange(recursiveMenus);

            if (!recursiveMenus.Any(m => m.ActivePage))
            {
                //recurse only for the pages that is in the selected page pagechain
                foreach (var recursiveMenu in recursiveMenus.Where(m => m.IsInChain))
                {
                    menu.AddRange(Load(recursiveMenu.PageData.PageLink, activePage, currentLevel+1));
                }
            }

            return menu;

        }

        public bool ActivePage { get; set; }


        public bool IsInChain { get; set; }
        public bool HaveChildren { get; set; }
    }
}
