using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Ignobilis.Models.Blocks;

namespace Ignobilis.Controllers
{
    public class ListBlockController : BlockController<IB_ListBlock>
    {
        public override ActionResult Index(IB_ListBlock currentBlock)
        {           
            return PartialView("~/Views/Ignobilis/Blocks/List/index.cshtml", 
                IgnobilisService.Instance.Settings.Functionality.Blocks.ListBlock.Load(currentBlock));
        }

    }
}
