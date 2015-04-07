using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;

namespace Ignobilis.Business.Global
{
    public class ThemeSelectionFactory : ISelectionFactory
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
                           Text = "Flashy",
                           Value = "Flashy"
                       },
                        new SelectItem
                       {
                           Text = "Theme-1",
                           Value = "Theme-1"
                       },
                       new SelectItem
                       {
                           Text = "Theme-2",
                           Value = "Theme-2"
                       },
                       new SelectItem
                       {
                           Text = "Theme-3",
                           Value = "Theme-3"
                       }
                   };
        }
    }
}