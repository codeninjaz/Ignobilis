using System;
using System.Collections.Generic;

namespace Ignobilis.Business.Interfaces
{
    public interface IFunctionality
    {
        IRecursiveMenu Menu { get; set; }

        IBreadCrumb BreadCrumb { get; set; }

        IMainMenu MainMenu { get; set; }

        ISecondaryMenu SecondaryMenu { get; set; }

        IViewMode ViewMode { get; set; }

        ITheme Theme { get; set; }

        IPageEvents PageEvents { get; set; }

        IBlocks Blocks { get; set; }

        Dictionary<String, Type> ContentLists { get; set; }

    }
    
}
