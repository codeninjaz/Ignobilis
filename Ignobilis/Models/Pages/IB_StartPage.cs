using EPiServer.DataAnnotations;
using Ignobilis.Business.Attributes;

namespace Ignobilis.Models.Pages
{
//    [SiteContentType(DisplayName = "StartPage", GUID = "c6a25fd7-80db-4d6f-98cd-c3841c9c12ce", Description = "", IsOfType = typeof(StartPage))]
    [ContentType(DisplayName = "StartPage (Ignobilis)", GUID = "c6a25fd7-80db-4d6f-98cd-c3841c9c12ce", Description = "")]
    //[SiteImageUrl(SiteImageUrl.ThumbNailPath.Start)]
    public class IB_StartPage : IB_BasePage
    {

    }
}