using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using Ignobilis.Business.Interfaces;

namespace Ignobilis.Business.Functionality
{
    public class SecondaryMenu : ISecondaryMenu
    {
        public List<PageData> Load(PageReference pageReference)
        {
            return ServiceLocator.Current.GetInstance<IContentRepository>().GetChildren<PageData>(pageReference).ToList();
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