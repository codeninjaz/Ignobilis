using EPiServer.Core;
using Ignobilis.Business.Interfaces;
using Ignobilis.Models.Pages;

namespace Ignobilis.Models.ViewModels
{
    /// <summary>
    /// Defines common characteristics for view models for pages, including properties used by layout files.
    /// </summary>
    /// <remarks>
    /// Views which should handle several page types (T) can use this interface as model type rather than the
    /// concrete PageViewModel class, utilizing the that this interface is covariant.
    /// </remarks>
    public interface IPageViewModel<out T> where T : IB_BasePage
    {
        T CurrentPage { get; }
        //LayoutModel Layout { get; set; }
        IContent Section { get; set; }

        IB_SettingsPage SettingsPage { get; set; }

        IProfile Profile { get; set; }
    }
    
}