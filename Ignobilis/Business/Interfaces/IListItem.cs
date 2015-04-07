using System;
using EPiServer;

namespace Ignobilis.Business.Interfaces
{
    public interface IListItem
    {
        Guid Id { get; set; }
        String Title { get; set; }

        String Description { get; set; }        

        Url Link { get; set; }

        String LinkText { get; set; }

        Url Image { get; set; }

        DateTime PublishedDate { get; set; }

        Boolean IsExternal { get; set; }
    }
}
