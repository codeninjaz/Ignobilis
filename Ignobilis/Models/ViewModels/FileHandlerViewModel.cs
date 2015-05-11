using System;

namespace Ignobilis.Models.ViewModels
{
    public class FileHandlerViewModel
    {
        public string RootFolderId { get; set; }
        public Guid BlockGuid { get; set; }
        public string ApiUrl { get; set; }
    }
}