using System;
using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace Ignobilis.Business.Global
{
    [EditorDescriptorRegistration(
        TargetType = typeof(string),
        UIHint = Strings.UIHints.ListBlockSorting)]
    public class ListBlockSortingSelector : EditorDescriptor
    {
        public override void ModifyMetadata(
                ExtendedMetadata metadata,
                IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(ListBlockSortingSelectionFactory);

            ClientEditingClass =
                "epi.cms.contentediting.editors.SelectionEditor";

            base.ModifyMetadata(metadata, attributes);
        }
    }
}