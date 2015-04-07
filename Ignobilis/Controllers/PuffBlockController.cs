using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Ignobilis.Models.Blocks;

namespace Ignobilis.Controllers
{
    public class PuffBlockController : BlockController<IB_PuffBlock>
    {
        public override ActionResult Index(IB_PuffBlock currentBlock)
        {
            return PartialView("~/Views/Ignobilis/Blocks/Puff/index.cshtml",currentBlock);
        }
    }
}
