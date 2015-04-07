using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace EPiServer.Templates.Alloy.Models.Media
{
    [ContentType(GUID = "5750F13D-37E2-4831-A7D9-BDC11C94B5AB")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageFile : ImageData, IContentImage
    {
        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        /// <value>
        /// The copyright.
        /// </value>
        public virtual string Copyright { get; set; }
    }
}