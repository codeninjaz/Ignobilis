using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;

namespace Ignobilis.Business.Global
{
    public class ViewModeSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new List<SelectItem>
                   {
                        new SelectItem
                       {
                           Text = "",
                           Value = ""
                       },
                        new SelectItem
                       {
                           Text = "1 Kolumn",
                           Value = "1-columns"
                       },
                        new SelectItem
                       {
                           Text = "2 Kolumner",
                           Value = "2-columns"
                       },
                       new SelectItem
                       {
                           Text = "3 Kolumner",
                           Value = "3-columns"
                       },
                       new SelectItem
                       {
                           Text = "4 Kolumner",
                           Value = "4-columns"
                       }
                   };
        }
    }
}