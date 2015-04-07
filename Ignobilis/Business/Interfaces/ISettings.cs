using System;
using System.Collections.Generic;

namespace Ignobilis.Business.Interfaces
{
    public interface ISettings
    {
        IPaths Paths { get; set; }

        List<String> CssClasses { get; set; }

        Dictionary<Type, String> PageGroupsDictionary { get; set; }

        List<String> TabNamesList { get; set; }

        IFunctionality Functionality { get; set; }

        Type ProfileType { get; set; }
    }
}
