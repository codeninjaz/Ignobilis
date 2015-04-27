using System.Collections.Generic;

namespace Ignobilis.Business.Interfaces
{
    public interface IBlockHub
    {
        void JoinBlockGroups(List<string> groupGuids);
        void LeaveBlockGroups(List<string> groupGuids);
    }
}
