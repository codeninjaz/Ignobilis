using System.Collections.Generic;
using EPiServer.Core;

namespace Ignobilis.Business.Interfaces
{
    public interface IBreadCrumb
    {
        List<IContent> Load(ContentReference currentPage);

        string Seperator { get; set; }

        string Message { get; set; }        
    }
}
