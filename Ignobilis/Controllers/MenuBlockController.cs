using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using Ignobilis.Business;
using Ignobilis.Models.Blocks;
using Ignobilis.Models.ViewModels;

namespace Ignobilis.Controllers
{
    public class MenuBlockController : BlockController<IB_MenuBlock>
    {
        public override ActionResult Index(IB_MenuBlock currentBlock)
        {
            var menuBlockViewModel = new MenuBlockViewModel
                                     {
                                         BlockGuid = (currentBlock as IContent).ContentGuid,
                                         Pages = new List<int>(),
                                         ChildrenFrom = new List<int>()
                                     };

            if (currentBlock.MenuItems != null)
            foreach (var childItem in currentBlock.MenuItems.ToPages())
            {
                menuBlockViewModel.Pages.Add(childItem.PageLink.ID);
            }

            if (currentBlock.ChildItems != null)
            foreach (var childItem in currentBlock.ChildItems.ToPages())
            {
                var list = DataFactory.Instance.GetChildren(childItem.PageLink).Select(m => m.PageLink.ID).ToList();
                menuBlockViewModel.ChildrenFrom.AddRange(list);
            }

            return PartialView("~/Views/Ignobilis/Blocks/Menu/index.cshtml", menuBlockViewModel);
        }
    }
}
