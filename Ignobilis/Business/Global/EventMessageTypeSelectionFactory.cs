using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Shell.ObjectEditing;
using EPiServer.XForms.WebControls;
using SelectItem = EPiServer.Shell.ObjectEditing.SelectItem;

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