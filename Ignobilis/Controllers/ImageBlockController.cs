using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Ignobilis.Models.Blocks;

namespace Ignobilis.Controllers
{
    public class ImageBlockController : BlockController<IB_ImageBlock>
    {
        public override ActionResult Index(IB_ImageBlock currentBlock)
        {
            return PartialView("~/Views/Ignobilis/Blocks/Image/index.cshtml", currentBlock);
        }
    }
}
