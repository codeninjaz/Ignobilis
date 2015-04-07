using System;
using System.Collections.Generic;
using EPiServer.SpecializedProperties;

namespace Ignobilis.Business.Interfaces
{
    public interface IList
    {
        List<IListItem> Items { get; set; }

        bool Init(LinkItemCollection linkCollection);

    }
}
