using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Ignobilis.Models.Blocks
{
    [ContentType(DisplayName = "IB_MenuBlock", GUID = "beff1762-a900-4073-937c-f9d3980525c2", Description = "")]
    public class IB_MenuBlock : IB_BaseBlock
    {
        [Display(
            Name = "Valda sidor",
            Description = "Dessa sidor väljs att visas i menyn-",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual LinkItemCollection MenuItems { get; set; }

        [Display(
            Name = "Hämta sidor från",
            Description = "Väljer att hämta barnen från dessa sidor.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual LinkItemCollection ChildItems { get; set; }
    }
}