using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.SpecializedProperties;

namespace Ignobilis.Business.Interfaces
{
    public interface IMainMenu
    {
        List<PageData> Load(LinkItemCollection links);

        bool LocatedInMenu(PageData currentPage, PageData menuPageData);

        PageData ActiveMenuItem { get; set; }
    }
}
