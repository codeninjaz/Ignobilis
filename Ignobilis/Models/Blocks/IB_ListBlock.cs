using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;

namespace Ignobilis.Models.Blocks
{
    [ContentType(DisplayName = "IB_ListBlock", GUID = "15bd0aa2-be0f-42a2-b50d-84138369508d", Description = "")]
    public class IB_ListBlock : IB_BaseBlock
    {        
        
        [CultureSpecific]
        [Display(
            Name = "Hämta dessa sidor",
            Description = "Om Typ av listkälla är 'Länklista' så används denna egenskap",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual LinkItemCollection LinkList { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Hämta undersidor från dessa sidor",
            Description = "Om Typ av listkälla är 'Innehållsträd' så används denna egenskap",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual LinkItemCollection ListContentTree { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Hämta information från dessa externa sidor",
            Description = "Om Typ av listkälla är 'RSS' så används denna egenskap",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual LinkItemCollection ExternalList { get; set; }

        [Display(
        Name = "Layout",
        Description = "Visningsläge för listningen",
        GroupName = SystemTabNames.Settings,
        Order = 2)]
        [UIHint(Business.Global.Strings.UIHints.ListBlockLayout)]
        public virtual String Layout { get; set; }

        [Display(
            Name = "Sortera på",
            Description = "Vad ska listan sorteras på?",
            GroupName = SystemTabNames.Settings,
            Order = 1)]
        [UIHint(Business.Global.Strings.UIHints.ListBlockSortMode)]
        public virtual String SortMode { get; set; }

        [Display(
            Name = "Sorteringsordning",
            Description = "Hur ska innehållet sorteras?",
            GroupName = SystemTabNames.Settings,
            Order = 2)]
        [UIHint(Business.Global.Strings.UIHints.ListBlockSorting)]
        public virtual String Sorting { get; set; }

        [Display(
            Name = "Antal per sida",
            Description = "Hur många element ska visas på samma sida?",
            GroupName = SystemTabNames.Settings,
            Order = 5)]
        public virtual int NumberPerPage { get; set; }

        [Display(
            Name = "Cachetid",
            Description = "Hur länge ska det cachelagras?",
            GroupName = SystemTabNames.Settings,
            Order = 6)]
        public virtual int CacheTime { get; set; }
    }
}