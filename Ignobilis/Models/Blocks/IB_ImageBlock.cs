using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Ignobilis.Models.Blocks
{
    [ContentType(DisplayName = "IB_ImageBlock", GUID = "bc494b0a-25d7-4683-8dc1-813cded0621d", Description = "")]
    public class IB_ImageBlock : IB_BaseBlock
    {        
        [UIHint(UIHint.Image)]
        [Display(
            Name = "Bild",
            Description = "Den bild som ska visas",
            GroupName = SystemTabNames.Content,
            Order = 1)]       
        public virtual ContentReference Image { get; set; }
    }
}