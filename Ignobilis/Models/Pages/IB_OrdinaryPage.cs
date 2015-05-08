using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Ignobilis.Business.Attributes;
using System.ComponentModel.DataAnnotations;
using Ignobilis.Business.Global;

namespace Ignobilis.Models.Pages
{
//    [SiteContentType(DisplayName = "OrdinaryPage", GUID = "bee8d7ef-8f74-4829-91a9-bd6081b9543e", Description = "", IsOfType = typeof(OrdinaryPage))]
    [ContentType(DisplayName = "OrdinaryPage", GUID = "bee8d7ef-8f74-4829-91a9-bd6081b9543e", Description = "")]
    //[SiteImageUrl(SiteImageUrl.ThumbNailPath.Ordinary)]
    public class IB_OrdinaryPage : IB_BasePage
    {
        [CultureSpecific]
        [Display(
            Name = "Ingress",
            Description = "Ingress på sidan eller alternativ ingress som visas i listningar.",
            GroupName = Strings.TabNames.Content,
            Order = 2)]
        [UIHint(UIHint.LongString)]
        public virtual string Ingress { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Puff",
            Description = "Jättekort beskrivning av sidan, för små puffar.",
            GroupName = Strings.TabNames.Content,
            Order = 6)]        
        public virtual string Puff { get; set; }
    }
}