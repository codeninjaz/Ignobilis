using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;
using SelectItem = EPiServer.Shell.ObjectEditing.SelectItem;

namespace Ignobilis.Business.Global
{
    public class ListBlockLayoutSelectionFactory : ISelectionFactory
    {
        public ListBlockLayoutSelectionFactory()
        {
            Types = new List<SelectItem>
                    {
                        new SelectItem
                        {
                            Text = "Simpel",
                            Value = Strings.ListLayoutSimple
                        },
                        new SelectItem
                        {
                            Text = "Nyhet",
                            Value = Strings.ListLayoutNews
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