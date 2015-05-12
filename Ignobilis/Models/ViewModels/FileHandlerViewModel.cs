using System;
using EPiServer.Core;

namespace Ignobilis.Models.ViewModels
{
    public class FileHandlerViewModel
    {
        public ContentReference RootFolder { get; set; }
        public Guid BlockGuid { get; set; }
        public string ApiUrl { get; set; }
    }
}