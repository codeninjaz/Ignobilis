using System.Web;
using Ignobilis.Models.Pages;

namespace Ignobilis.Business.Interfaces
{
    public interface ITheme
    {
        string Load(IB_SettingsPage settingsPage);
    }
}
