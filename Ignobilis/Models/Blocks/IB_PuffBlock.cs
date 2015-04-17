using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace Ignobilis.Models.Blocks
{
    [ContentType(DisplayName = "IB_PuffBlock", GUID = "e7ec25f8-9505-44b5-ae0f-69616653a140", Description = "")]
    public class IB_PuffBlock : IB_BaseBlock
    {
        [CultureSpecific]
        [UIHint(UIHint.Image)]
        [Display(
            Name = "Bild",
            Description = "Bild för blocket.",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual ContentReference Image { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Beskrivning",
            Description = "Text på blocket som visas som en information.",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        [UIHint(UIHint.LongString)]
        public virtual string Description { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Länkar för mer information",
            Description = "Länkar till vidare information",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual LinkItemCollection Links { get; set; }
        
        [Display(
            Name = "Pufftyp",
            Description = "Vad är detta för typ av puff?",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        [UIHint(Business.Global.Strings.UIHints.EventMessageType)]
        public virtual String PuffType { get; set; }
    }
}