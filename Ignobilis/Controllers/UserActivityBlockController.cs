using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using Ignobilis.Models.Blocks;
using Ignobilis.Models.ViewModels;

namespace Ignobilis.Controllers
{
    public class UserActivityBlockController : BlockController<IB_UserActivity>
    {
        public override ActionResult Index(IB_UserActivity currentBlock)
        {
            var userActivityViewModel = new UserActivityViewModel
                                     {
                                         BlockGuid = (currentBlock as IContent).ContentGuid
                                     };

            return PartialView("~/Views/Ignobilis/Blocks/UserActivity/index.cshtml", userActivityViewModel); 
        }
    }
}
