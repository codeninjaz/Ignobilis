using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Ignobilis.Models.Blocks
{
    [ContentType(DisplayName = "IB_BaseBlock", GUID = "be0b77ba-c60c-4f1a-aa71-33409fe3d1e6", Description = "", AvailableInEditMode = false)]
    public class IB_BaseBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Rubrik",
            Description = "Den rubrik som eventuellt ska visas för blocket",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual String Header { get; set; }
    }
}