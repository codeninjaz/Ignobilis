using System;

namespace Ignobilis.Business.Interfaces
{
    public interface IBlockHub
    {
        void JoinBlockGroup(string groupGuid);
        void LeaveBlockGroup(string groupGuid);
        void JoinGroup(string group);
        void LeaveGroup(string group);
    }
}
