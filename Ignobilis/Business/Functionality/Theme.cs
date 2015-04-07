using Ignobilis.Business.Interfaces;
using Ignobilis.Models.Pages;

namespace Ignobilis.Business.Functionality
{
    public class Theme : ITheme
    {
        public string Load(IB_SettingsPage settingsPage)
        {
            return settingsPage.Theme;
        }
    }
}