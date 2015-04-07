using System.Web;
using Ignobilis.Models.Pages;

namespace Ignobilis.Business.Interfaces
{
    public interface IViewMode
    {
        string Load(IB_BasePage currentPage, IB_SettingsPage settingsPage, HttpContext context = null);
    }
}
