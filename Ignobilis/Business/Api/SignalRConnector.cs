using System;
using System.Collections.Generic;
using Ignobilis.Models.Pages;
using Microsoft.AspNet.SignalR;

namespace Ignobilis.Business.Api
{
    public class SignalRConnector
    {
        private readonly static Lazy<EventMessageConnector> EventMessageInstance = 
            new Lazy<EventMessageConnector>(() => new EventMessageConnector(GlobalHost.ConnectionManager.GetHubContext<EventMessageHub>()));

        private readonly static Lazy<UserActivityConnector> UserActivityInstance =
            new Lazy<UserActivityConnector>(() => new UserActivityConnector(GlobalHost.ConnectionManager.GetHubContext<UserActivityHub>()));

        public static EventMessageConnector EventMessage
        {
            get { return EventMessageInstance.Value; }
        }

        public static UserActivityConnector UserActivity
        {
            get { return UserActivityInstance.Value; }
        }

        public class EventMessageConnector
        {
            private readonly IHubContext _hub;
            public EventMessageConnector(IHubContext context)
            {
                _hub = context;
            }
            
            public void Clear()
            {
                _hub.Clients.All.clearMessages();
            }

            public void Send(IB_EventMessage message)
            {
                var link = message.LinkUrl ?? "";

                if (string.IsNullOrEmpty(message.Group))
                {
                    _hub.Clients.All.broadcastMessage(message.Type, message.EventMessage, link.OriginalString);
                }
                else
                {
                    _hub.Clients.Group(message.Group.ToLower()).broadcastMessage(message.Type, message.EventMessage, link.OriginalString);
                }
            }
        }

        public class UserActivityConnector
        {
            private readonly IHubContext _hub;
            public UserActivityConnector(IHubContext context)
            {
                _hub = context;
            }

            public void SendConnectionInfo(UserActivityInformation info, List<string> blockGroups)
            {
                foreach (var bGroup in blockGroups)
                {
                    _hub.Clients.Group(bGroup).updateUsersOnlineCount(info, bGroup);
                }                                
            }
            
        }
    }
}