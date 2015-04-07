using System;
using System.Collections.Generic;

namespace Ignobilis.Business.Interfaces
{
    public interface IPaths
    {
        string BaseGraphics { get; set; }
        string OrdinaryPageTypeThumbnail { get; set; }
        string DefaultPageTypeThumbnail { get; set; }
        string StartPageTypeThumbnail { get; set; }

        List<String> CssList { get; set; }

        List<String> Scripts { get; set; } 
    }
}
