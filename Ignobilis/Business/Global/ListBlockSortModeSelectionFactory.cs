using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;
using SelectItem = EPiServer.Shell.ObjectEditing.SelectItem;

namespace Ignobilis.Business.Global
{
    public class ListBlockSortModeSelectionFactory : ISelectionFactory
    {
        public ListBlockSortModeSelectionFactory()
        {
            Types = new List<SelectItem>
                    {
                        new SelectItem
                        {
                            Text = "Titel",
                            Value = Strings.SortModeTitle
                        },
                        new SelectItem
                        {
                            Text = "Datum",
                            Value = Strings.SortModeDate
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