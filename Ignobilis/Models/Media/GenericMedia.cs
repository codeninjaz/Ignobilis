using EPiServer.Core;
using EPiServer.DataAnnotations;
using System;

namespace EPiServer.Templates.Alloy.Models.Media
{
    [ContentType(GUID = "F3517510-2597-4AAA-9C2F-F906A8F6DE5C")]
    public class GenericMedia : MediaData
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public virtual String Description { get; set; }
    }
}