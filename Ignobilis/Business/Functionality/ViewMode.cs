using System;
using System.Web;
using Castle.Core.Internal;
using Ignobilis.Business.Interfaces;
using Ignobilis.Models.Pages;

namespace Ignobilis.Business.Functionality
{
    public class ViewMode : IViewMode
    {
        public string Load(IB_BasePage currentPage, IB_SettingsPage settingsPage)
        {
            return !currentPage.ViewMode.IsNullOrEmpty() ? currentPage.ViewMode : settingsPage.ViewMode;
        }

        public string Load(IB_BasePage currentPage, IB_SettingsPage settingsPage, HttpContext context = null)
        {
            var viewMode = !currentPage.ViewMode.IsNullOrEmpty() ? currentPage.ViewMode : settingsPage.ViewMode;

            if (context == null)
            {
                return viewMode;
            }

            var viewModeQueryString = context.Request.QueryString.Get("viewmode");

            if (viewModeQueryString.IsNullOrEmpty())
            {
                return viewMode;
            }

            return viewModeQueryString;
        }
    }
}