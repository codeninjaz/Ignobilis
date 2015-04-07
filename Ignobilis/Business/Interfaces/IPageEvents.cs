using System.Collections.Generic;
using EPiServer;
using Ignobilis.Models.Pages;

namespace Ignobilis.Business.Interfaces
{
    public interface IPageEvents
    {
        List<IB_EventMessage> EventMessages(string group);

        void OnPublishedPage(object sender, PageEventArgs eventArgs);
    }
}
