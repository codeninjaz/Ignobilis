using System;

namespace Ignobilis.Business.Attributes
{
    public class ContentSelectionAttribute : Attribute
    {
        public ContentSelectionAttribute(Type contentType)
        {
            ContentType = contentType;
        }

        public Type ContentType { get; set; }
    }
}