using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;
using SelectItem = EPiServer.Shell.ObjectEditing.SelectItem;

namespace Ignobilis.Business.Global
{
    public class ListBlockSortingSelectionFactory : ISelectionFactory
    {
        public ListBlockSortingSelectionFactory()
        {
            Types = new List<SelectItem>
                    {
                        new SelectItem
                        {
                            Text = "Fallande",
                            Value = Strings.SortingDesc
                        },
                        new SelectItem
                        {
                            Text = "Stigande",
                            Value = Strings.SortingAsc
                        }
                    };
        }

        public List<SelectItem> Types { get; set; }

        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return Types;
        }
    }
}