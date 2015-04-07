using System.Collections.Generic;
using Ignobilis.Business.Interfaces;

namespace Ignobilis.Business.Global
{
    public class ListItemEqualityComparer : IEqualityComparer<IListItem>
    {
        public bool Equals(IListItem x, IListItem y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(IListItem obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}