using Ignobilis.Business.Interfaces;

namespace Ignobilis.Business.Functionality
{
    public class Blocks : IBlocks
    {
        public Blocks()
        {
            ListBlock = new ListBlock();
        }

        public IListBlock ListBlock { get; set; }
    }
}