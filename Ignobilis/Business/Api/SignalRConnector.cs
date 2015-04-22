using System;
using Ignobilis.Models.Pages;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Ignobilis.Business.Api
{
    public class SignalRConnector
    {
        private readonly static Lazy<EventMessageConnector> _eventMessageInstance = 
            new Lazy<EventMessageConnector>(() => new EventMessageConnector(GlobalHost.ConnectionManager.GetHubContext<EventMessageHub>().Clients));

        public static EventMessageConnector EventMessage
        {
            get { return _eventMessageInstance.Value; }
        }

        public class EventMessageConnector
        {
            private readonly IHubConnectionContext<dynamic> _clients;
            public EventMessageConnector(IHubConnectionContext<dynamic> context)
            {
                _clients = context;
            }
            
            public void Clear()
            {
                _clients.All.clearMessages();
            }

            public void Send(IB_EventMessage message)
            {
                var link = message.LinkUrl ?? "";

                if (string.IsNullOrEmpty(message.Group))
                {
                    _clients.All.broadcastMessage(message.Type, message.EventMessage, link.OriginalString);
                }
                else
                {
                    _clients.Group(message.Group.ToLower()).broadcastMessage(message.Type, message.EventMessage, link.OriginalString);
                }
            }
        }
    }
}