using Microsoft.AspNet.SignalR;

namespace Ignobilis.Business.Api
{
    public class EventMessageHub : Hub
    {
        public void JoinGroup(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);            
        }

        public void LeaveGroup(string groupName)
        {
            Groups.Remove(Context.ConnectionId, groupName);
        }
    }
}