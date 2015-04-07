using System;
using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace Ignobilis.Business.Global
{
    [EditorDescriptorRegistration(
        TargetType = typeof(string),
        UIHint = Strings.UIHints.ViewMode)]
    public class ThemeSelector : EditorDescriptor
    {
        public override void ModifyMetadata(
                ExtendedMetadata metadata,
                IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(ViewModeSelectionFactory);

            ClientEditingClass =
                "epi.cms.contentediting.editors.SelectionEditor";

            base.ModifyMetadata(metadata, attributes);
        }
    }


}