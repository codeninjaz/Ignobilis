using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.SpecializedProperties;
using Ignobilis.Business.Interfaces;

namespace Ignobilis.Business.Functionality
{
    class MainMenu : IMainMenu
    {
        private List<PageData> MainMenuLinks { get; set; }

        public List<PageData> Load(LinkItemCollection links)
        {
            if (links == null || links.Count == 0)
            {
                return ServiceLocator.Current.GetInstance<IContentRepository>().GetChildren<PageData>(ContentReference.StartPage).ToList();
            }
            
            MainMenuLinks = links.ToPages();
            return MainMenuLinks;
        }

        public bool LocatedInMenu(PageData currentPage, PageData menuPageData)
        {
            var menuItemFound = currentPage.ContentGuid == menuPageData.ContentGuid;
            if (menuItemFound)
            {
                ActiveMenuItem = menuPageData;
                return true;
            }

            var ancestors = ServiceLocator.Current.GetInstance<IContentRepository>().GetAncestors(currentPage.PageLink).ToList();

            menuItemFound = ancestors.Any(m => m.ContentGuid == menuPageData.ContentGuid);
            if (menuItemFound)
            {
                ActiveMenuItem = menuPageData;
            }

            return menuItemFound;
        }

        public PageData ActiveMenuItem { get; set; }
    }
}
