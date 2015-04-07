using Ignobilis.Models.Blocks;
using Ignobilis.Models.ViewModels;

namespace Ignobilis.Business.Interfaces
{
    public interface IListBlock
    {
        ListBlockViewModel Load(IB_ListBlock currentBlock);
    }
}
