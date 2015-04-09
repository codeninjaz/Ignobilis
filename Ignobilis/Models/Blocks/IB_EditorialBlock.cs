using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Ignobilis.Models.Blocks
{
    [ContentType(DisplayName = "IB_PuffBlock", GUID = "df82ab6e-6123-40d9-a45f-ad8cf64dd970", Description = "")]
    public class IB_EditorialBlock : IB_BaseBlock
    {        
        [CultureSpecific]
        [Display(
            Name = "Huvudinnehåll",
            Description = "Text på blocket som visas som en information.",
            GroupName = SystemTabNames.Content,
            Order = 1)]        
        public virtual XhtmlString MainBody { get; set; }
    }
}