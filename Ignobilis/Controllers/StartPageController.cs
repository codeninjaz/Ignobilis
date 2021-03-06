﻿using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Ignobilis.Models.Pages;
using Ignobilis.Models.ViewModels;

namespace Ignobilis.Controllers
{
    public class StartPageController : PageController<IB_StartPage>
    {
        public ActionResult Index(IB_StartPage currentPage)
        {
            var pageViewModel = new PageViewModel<IB_StartPage>(currentPage,User);

            return View("~/Views/Ignobilis/Pages/StartPage/Index.cshtml", pageViewModel);
        }
    }
}