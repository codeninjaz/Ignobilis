using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Ignobilis.Models.Pages;
using Ignobilis.Models.ViewModels;

namespace Ignobilis.Controllers
{
    public class OrdinaryPageController : PageController<IB_OrdinaryPage>
    {
        public ActionResult Index(IB_OrdinaryPage currentPage)
        {                        
            var pageViewModel = new PageViewModel<IB_OrdinaryPage>(currentPage, User);
            return View("~/Views/Ignobilis/Pages/OrdinaryPage/Index.cshtml", pageViewModel);
        }
    }
}