using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;

namespace EPiServer.Templates.Alloy.Models.Media
{
    [ContentType(GUID = "B9E095E3-7A0C-4833-B301-B75BB431EB6A")]
    [MediaDescriptor(ExtensionString = "flv,mp4,webm")]
    public class VideoFile : VideoData
    {
        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        public virtual string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the URL to the preview image.
        /// </summary>
        [UIHint(UIHint.Image)]
        public virtual ContentReference PreviewImage { get; set; }
   }
}