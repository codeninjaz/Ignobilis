using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;

namespace Ignobilis.Business.Global
{
    public class EventMessageTypeSelectionFactory : ISelectionFactory
    {
        public EventMessageTypeSelectionFactory()
        {
            Types = new List<SelectItem>
                    {
                        new SelectItem
                        {
                            Text = "",
                            Value = ""
                        },
                        new SelectItem
                        {
                            Text = "Akut",
                            Value = "emergency"
                        },
                        new SelectItem
                        {
                            Text = "Varning",
                            Value = "warning"
                        },
                        new SelectItem
                        {
                            Text = "Fel",
                            Value = "error"
                        },
                        new SelectItem
                        {
                            Text = "Information",
                            Value = "information"
                        },
                        new SelectItem
                        {
                            Text = "Standard",
                            Value = "default"
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