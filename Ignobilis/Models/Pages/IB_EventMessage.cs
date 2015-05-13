using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Ignobilis.Business.Global;

namespace Ignobilis.Models.Pages
{
    [ContentType(DisplayName = "IB_EventMessage", GUID = "b2c6d754-bb29-46ba-ba5b-9642526935c2", Description = "")]
    public class IB_EventMessage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Meddelande",
            Description = "Det meddelande som ska förmedlas vidare",
            GroupName = Strings.TabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Textarea)]
        [Required(ErrorMessage = "Meddelandet måste fyllas i")]
        public virtual String EventMessage { get; set; }

        [Display(
            Name = "Länk för mer information",
            Description = "Vill man visa ytterligare information så får man följa denna länk",
            GroupName = Strings.TabNames.Content,
            Order = 2)]
        public virtual Url LinkUrl { get; set; }


        [Display(
            Name = "Sidan skapad utav sidan",
            Description = "Denna sida har blivit skapad utav ett formulär från denna sida",
            GroupName = Strings.TabNames.Settings,
            Order = 3)]
        public virtual ContentReference Creator { get; set; }

        [Display(
            Name = "Visa för grupp",
            Description = "Detta fält används för att meddela en specifik besökargrupp",
            GroupName = Strings.TabNames.Settings,
            Order = 3)]
        public virtual String Group { get; set; }


        [Display(
        Name = "Meddelandetyp",
        Description = "Beskrivning vad det är för typ av meddelande",
        GroupName = Strings.TabNames.Settings,
        Order = 3)]
        [Required]
        [UIHint(Strings.UIHints.EventMessageType)]
        public virtual String Type { get; set; }

    }
}