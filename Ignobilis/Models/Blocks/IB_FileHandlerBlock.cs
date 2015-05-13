using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
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
            Name = "Rotkatalog",
            Description = "Länk till rotkatalog",
            GroupName = SystemTabNames.Settings,
            Order = 1)]
        public virtual ContentReference RootFolder { get; set; }
    }
}