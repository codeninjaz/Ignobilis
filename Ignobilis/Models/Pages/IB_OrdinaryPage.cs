using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Ignobilis.Business.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Ignobilis.Models.Pages
{
//    [SiteContentType(DisplayName = "OrdinaryPage", GUID = "bee8d7ef-8f74-4829-91a9-bd6081b9543e", Description = "", IsOfType = typeof(OrdinaryPage))]
    [ContentType(DisplayName = "OrdinaryPage", GUID = "bee8d7ef-8f74-4829-91a9-bd6081b9543e", Description = "")]
    //[SiteImageUrl(SiteImageUrl.ThumbNailPath.Ordinary)]
    public class IB_OrdinaryPage : IB_BasePage
    {
        [CultureSpecific]
        [Display(
            Name = "Sidansvarig",
            Description = "Ansvarig för sidans innehåll.",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual string PageResponsible { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Image)]
        [Display(
            Name = "Bild på sidan",
            Description = "Bild överst på sidan.",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual ContentReference Image { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Ingress",
            Description = "Ingress på sidan eller alternativ ingress som visas i listningar.",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        [UIHint(UIHint.LongString)]
        public virtual string Ingress { get; set; }
    }
}