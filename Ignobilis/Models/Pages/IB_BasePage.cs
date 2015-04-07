using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Ignobilis.Business.Attributes;
using EPiServer.Web;

namespace Ignobilis.Models.Pages
{
//    [SiteContentType(DisplayName = "BasePage", GUID = "2304b7a2-c114-4909-8762-92d0175f987c", Description = "", AvailableInEditMode = false)]
    [ContentType(DisplayName = "BasePage", GUID = "2304b7a2-c114-4909-8762-92d0175f987c", Description = "", AvailableInEditMode = false)]
//    [SiteImageUrl(SiteImageUrl.ThumbNailPath.Default)]
    public class IB_BasePage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Rubrik",
            Description = "Visas som rubrik på sidan.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Headline { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Huvudeditor",
            Description = "Texten kommer att visas i innehållsdelen på sidan, med hjälp av detta fält kan du infoga exempelvis text, bilder och tabeller.",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual XhtmlString MainBody { get; set; }



        #region Areor
        [Display(
            Name = "Area A",
            Description="Area för block under det vanliga innehållet.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [CultureSpecific]
        public virtual ContentArea ContentAreaA { get; set; }

        [Display(
            Name="Area B",
            Description = "Area för block till vänster om det vanliga innehållet och under vänsternavigeringen.",
            GroupName = SystemTabNames.Content,
            Order = 110)]
        [CultureSpecific]
        public virtual ContentArea ContentAreaB { get; set; }

        [Display(
            Name = "Area C",
            Description = "Area för block till höger om det vanliga innehållet och under högerkolumnens innehåll.",
            GroupName = SystemTabNames.Content,
            Order = 120)]
        [CultureSpecific]
        public virtual ContentArea ContentAreaC { get; set; }

        [Display(
            Name = "Area D",
            Description = "Area för block till höger om det vanliga innehållet och under högerkolumnens innehåll.",
            GroupName = SystemTabNames.Content,
            Order = 130)]
        [CultureSpecific]
        public virtual ContentArea ContentAreaD { get; set; }

        [Display(
            Name = "Area E",
            Description = "Area för block till höger om det vanliga innehållet och under högerkolumnens innehåll.",
            GroupName = SystemTabNames.Content,
            Order = 140)]
        [CultureSpecific]
        public virtual ContentArea ContentAreaE { get; set; }

        [Display(
            Name = "Area F",
            Description = "Area för block till höger om det vanliga innehållet och under högerkolumnens innehåll.",
            GroupName = SystemTabNames.Content,
            Order = 140)]
        [CultureSpecific]
        public virtual ContentArea ContentAreaF { get; set; }
       
        [Display(
            Name = "Footerarea",
            Description = "Area för block under allt övrigt innehåll men innan footern.",
            GroupName = SystemTabNames.Content,
            Order = 130)]
        [CultureSpecific]
        public virtual ContentArea FooterContentArea { get; set; }
        
        [Display(
            Name = "Topparea",
            Description = "Area för block ovanför allt övrigt innehåll men under menyn.",
            GroupName = SystemTabNames.Content,
            Order = 130)]
        [CultureSpecific]
        public virtual ContentArea TopContentArea { get; set; }

        #endregion

        [Display(
            Name = "Visningsläge",
            Description = "3 kolumner, 4 kolumner.",
            GroupName = SystemTabNames.Content,
            Order = 7)]
        [UIHint(Business.Global.Strings.UIHints.ViewMode)]
        public virtual string ViewMode { get; set; }

    }
}