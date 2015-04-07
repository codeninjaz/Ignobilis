using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Ignobilis.Models.Pages
{
    [ContentType(DisplayName = "Inställningssida - ib", GUID = "b8df2d4d-c16e-45e1-b6d2-bf3c0d0ef3f7", 
        Description = "Inställningar vilket pekas ut från en dynamiskegenskap", 
        AvailableInEditMode = true)]
    public class IB_SettingsPage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Huvudmeny",
            Description = "Ingångarna för siten",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual LinkItemCollection MainMenu { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Aktivera den sekundära menyn",
            Description = "Är denna aktiv skapas en menu under huvudmenyn",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual bool IsSecondaryMenuActive { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Aktivera brödsmulor",
            Description = "Är denna aktiv skapas skapas brödsmulor som beskriver vart man är på siten",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual bool IsBreadCrumbsActive { get; set; }

        [Display(
            Name = "Puffarea",
            Description = "Area för block vid sidan av innehållet.",
            GroupName = SystemTabNames.Content,
            Order = 6)]
        [CultureSpecific]
        public virtual ContentArea PuffContentArea { get; set; }

        [Display(
            Name = "Searcharea",
            Description = "Area för sök",
            GroupName = SystemTabNames.Content,
            Order = 7)]
        [CultureSpecific]
        public virtual ContentArea SearchContentArea { get; set; }

        [Display(
            Name = "Personaliseringsarea",
            Description = "Area för personalisering",
            GroupName = SystemTabNames.Content,
            Order = 7)]
        [CultureSpecific]
        public virtual ContentArea PersonalizationContentArea { get; set; }

        [Display(
            Name = "Visningsläge",
            Description = "3 kolumner, 4 kolumner.",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        [UIHint(Business.Global.Strings.UIHints.ViewMode)]
        public virtual string ViewMode { get; set; }

        [Display(
            Name = "Tema",
            Description = "Flashy, theme-1",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        [UIHint(Business.Global.Strings.UIHints.Theme)]
        public virtual string Theme { get; set; }

        [Display(
            Name = "Root för meddelanden",
            Description = "Root för meddelanden som kommer visas på webbplatsen",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        public virtual ContentReference EventMessageRoot { get; set; }

    }
}
