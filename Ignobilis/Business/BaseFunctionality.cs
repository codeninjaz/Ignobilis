using System;
using System.Collections.Generic;
using Ignobilis.Business.Functionality;
using Ignobilis.Business.Global;
using Ignobilis.Business.Interfaces;

namespace Ignobilis.Business
{
    public class BaseFunctionality : IFunctionality
    {
        public BaseFunctionality()
        {
            Menu = new RecursiveMenu();
            BreadCrumb = new BreadCrumb();
            MainMenu = new MainMenu();
            SecondaryMenu = new SecondaryMenu();
            ViewMode = new ViewMode();
            Theme = new Theme();
            PageEvents = new PageEvents();
            Blocks = new Blocks();

            ContentLists = new Dictionary<string, Type>
                           {
                               {Strings.ListContentTree, typeof(ListContentTree)},
                               {Strings.LinkList, typeof(LinkList)},
                               {Strings.ExternalList, typeof(ExternalList)},
                           };
        }

        public IRecursiveMenu Menu { get; set; }
        public IBreadCrumb BreadCrumb { get; set; }
        public IMainMenu MainMenu { get; set; }
        public ISecondaryMenu SecondaryMenu { get; set; }
        public IViewMode ViewMode { get; set; }
        public ITheme Theme { get; set; }
        public IPageEvents PageEvents { get; set; }
        public IBlocks Blocks { get; set; }
        public Dictionary<string, Type> ContentLists { get; set; }
    }
}