using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ignobilis.Business.Interfaces;
using Microsoft.AspNet.SignalR;

namespace Ignobilis.Business.Api
{
    public class UserActivityHub : Hub, IBlockHub
    {
        public delegate void HubOnConnected();

        private List<string> _userList = new List<string>();
        private Dictionary<string, List<string>> _groupWithUsers = new Dictionary<string, List<string>>();
        private List<string> _blocks = new List<string>();

        public static UserActivityInformation Users = new UserActivityInformation {GroupConnections = new Dictionary<string, int>()};

        public void JoinBlockGroup(string groupGuid)
        {
            Groups.Add(Context.ConnectionId, groupGuid);
            _blocks.Add(groupGuid);
            SignalRConnector.UserActivity.SendConnectionInfo(Users, _blocks);
        }

        public void LeaveBlockGroup(string groupGuid)
        {
            Groups.Remove(Context.ConnectionId, groupGuid);            
        }

        public void JoinGroup(string groupName)
        {            
            if (!_groupWithUsers.ContainsKey(groupName))
            {
                _groupWithUsers.Add(groupName, new List<string>{ Context.ConnectionId });
            }
            else
            {
                if (_groupWithUsers[groupName].Contains(Context.ConnectionId)) return;

                _groupWithUsers[groupName].Add(Context.ConnectionId);
            }

            UpdateGroupCount(groupName, _groupWithUsers[groupName].Count);
        }

        public void LeaveGroup(string groupName)
        {   
            if (!_groupWithUsers.ContainsKey(groupName)) return;
            if (!_groupWithUsers[groupName].Contains(Context.ConnectionId)) return;

            _groupWithUsers[groupName].Remove(Context.ConnectionId);
            UpdateGroupCount(groupName, _groupWithUsers[groupName].Count);
        }

        private void UpdateGroupCount(string groupName, int count)
        {
            if (Users.GroupConnections.ContainsKey(groupName))
            {
                Users.GroupConnections[groupName] = count;
            }
            else
            {
                Users.GroupConnections.Add(groupName, count);
            }

            SignalRConnector.UserActivity.SendConnectionInfo(Users, _blocks);
        }

        public override Task OnConnected()
        {
            var clientId = GetClientId();
            if (_userList.IndexOf(clientId) == -1) { _userList.Add(clientId); }
            Users.TotalNumberOfConnections = _userList.Count;

            SignalRConnector.UserActivity.SendConnectionInfo(Users, _blocks);

            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            var clientId = GetClientId();
            if (_userList.IndexOf(clientId) == -1) { _userList.Add(clientId); }
            Users.TotalNumberOfConnections = _userList.Count;

            SignalRConnector.UserActivity.SendConnectionInfo(Users, _blocks);

            return base.OnReconnected();
        }        

        public override Task OnDisconnected(bool stopCalled)
        {
            var clientId = GetClientId();
            if (_userList.IndexOf(clientId) > -1) { _userList.Remove(clientId); }
            Users.TotalNumberOfConnections = _userList.Count;

            SignalRConnector.UserActivity.SendConnectionInfo(Users, _blocks);

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


    public class UserActivityInformation
    {
        public int TotalNumberOfConnections { get; set; }
        public Dictionary<string, int> GroupConnections { get; set; }
    }
}