using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Ignobilis.Models.Blocks;

namespace Ignobilis.Controllers
{
    public class EditorialBlockController : BlockController<IB_EditorialBlock>
    {
        public override ActionResult Index(IB_EditorialBlock currentBlock)
        {
            return PartialView("~/Views/Ignobilis/Blocks/Editorial/index.cshtml", currentBlock);
        }
    }
}
