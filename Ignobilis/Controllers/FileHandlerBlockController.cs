using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using Ignobilis.Models.Blocks;
using Ignobilis.Models.ViewModels;

namespace Ignobilis.Controllers
{
    public class FileHandlerBlockController : BlockController<IB_FileHandler>
    {
        public override ActionResult Index(IB_FileHandler currentBlock)
        {
            var content = currentBlock as IContent;
            
            if (content == null) return null;
            
            var fileHandlerViewModel = new FileHandlerViewModel
            {
                BlockGuid = content.ContentGuid,
                ApiUrl = currentBlock.Api,
                RootFolder = currentBlock.RootFolder
            };

            return PartialView("~/Views/Ignobilis/Blocks/FileHandler/index.cshtml", fileHandlerViewModel);
        }
    }
}
