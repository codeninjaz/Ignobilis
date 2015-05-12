using System.Collections.Generic;
using EPiServer.Core;

namespace Ignobilis.Business.Interfaces
{
    public interface IRecursiveMenu
    {
        PageData PageData { get; set; }
        int Level { get; set; }
        List<IRecursiveMenu> Load(PageReference start, PageReference activePage, int currentLevel = 0);

        bool ActivePage { get; set; }

        bool IsInChain { get; set; }

        bool HaveChildren { get; set; }
    }
}
