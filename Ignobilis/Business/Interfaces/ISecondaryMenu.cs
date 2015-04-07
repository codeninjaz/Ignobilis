using System.Collections.Generic;
using EPiServer.Core;

namespace Ignobilis.Business.Interfaces
{
    public interface ISecondaryMenu
    {
        List<PageData> Load(PageReference pageReference);

        bool LocatedInMenu(PageData currentPage, PageData menuPageData);

        PageData ActiveMenuItem { get; set; }
    }
}
