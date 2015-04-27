using System.Collections.Generic;
using System.Threading.Tasks;
using Ignobilis.Business.Interfaces;
using Microsoft.AspNet.SignalR;

namespace Ignobilis.Business.Api
{
    public class UserActivityHub : Hub, IBlockHub
    {
        public void JoinBlockGroups(List<string> groupGuids)
        {
            foreach (var guid in groupGuids)
            {
                Groups.Add(GetClientId(), guid);
                UserConnections.Instance.Blocks.Add(guid);
            }

            SignalRConnector.UserActivity.SendConnectionInfo(UserConnections.Instance.UserActivity, UserConnections.Instance.Blocks);
        }

        public void LeaveBlockGroups(List<string> groupGuids)
        {
            foreach (var guid in groupGuids)
            {
                Groups.Remove(GetClientId(), guid); 
            }
        }

        public override Task OnConnected()
        {
            var clientId = GetClientId();
            if (UserConnections.Instance.UserList.IndexOf(clientId) == -1) { UserConnections.Instance.UserList.Add(clientId); }
            UserConnections.Instance.UserActivity.TotalNumberOfConnections = UserConnections.Instance.UserList.Count;

            SignalRConnector.UserActivity.SendConnectionInfo(UserConnections.Instance.UserActivity, UserConnections.Instance.Blocks);
            
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            var clientId = GetClientId();
            if (UserConnections.Instance.UserList.IndexOf(clientId) == -1) { UserConnections.Instance.UserList.Add(clientId); }
            UserConnections.Instance.UserActivity.TotalNumberOfConnections = UserConnections.Instance.UserList.Count;

            SignalRConnector.UserActivity.SendConnectionInfo(UserConnections.Instance.UserActivity, UserConnections.Instance.Blocks);

            return base.OnReconnected();
        }        

        public override Task OnDisconnected(bool stopCalled)
        {
            var clientId = GetClientId();
            if (UserConnections.Instance.UserList.IndexOf(clientId) > -1) { UserConnections.Instance.UserList.Remove(clientId); }
            UserConnections.Instance.UserActivity.TotalNumberOfConnections = UserConnections.Instance.UserList.Count;

            SignalRConnector.UserActivity.SendConnectionInfo(UserConnections.Instance.UserActivity, UserConnections.Instance.Blocks);

            return base.OnDisconnected(stopCalled);
        }

        private string GetClientId()
        {
            var clientId = "";
            if (Context.QueryString["clientId"] != null)
            {
                clientId = Context.QueryString["clientId"];
            }

            if (string.IsNullOrEmpty(clientId.Trim()))
            {
                clientId = Context.ConnectionId;
            }

            return clientId;
        }
        

    }


    public class UserConnections
    {
        private UserConnections()
        {
            UserActivity = new UserActivityInformation();
            UserList = new List<string>();
            Blocks = new List<string>();
        }

        private static UserConnections _instance;
        public static UserConnections Instance
        {
            get { return _instance ?? (_instance = new UserConnections()); }
        }

        public UserActivityInformation UserActivity { get; set; }

        public List<string> UserList { get; set; } 
        public List<string> Blocks { get; set; }
    }

    public class UserActivityInformation
    {
        public int TotalNumberOfConnections { get; set; }
    }
}