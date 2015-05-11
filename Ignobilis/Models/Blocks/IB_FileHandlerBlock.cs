using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Ignobilis.Models.Blocks
{
    [ContentType(DisplayName = "IB_FileHandler", GUID = "d04be937-c12e-44d9-91aa-2bd37b5e6389", Description = "")]
    public class IB_FileHandler : IB_BaseBlock
    {
        [Display(
            Name = "Adress till API",
            Description = "url till det api som hanterar filer",
            GroupName = SystemTabNames.Settings,
            Order = 1)]
        public virtual string Api { get; set; }

        [Display(
            Name = "Id för rotkatalog",
            Description = "Id för rotkatalogen (beror på API)",
            GroupName = SystemTabNames.Settings,
            Order = 1)]
        public virtual string RootFolderId { get; set; }
    }
}