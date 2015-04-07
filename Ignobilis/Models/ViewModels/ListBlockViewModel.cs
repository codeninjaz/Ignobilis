using System.Collections.Generic;
using Ignobilis.Business.Interfaces;

namespace Ignobilis.Models.ViewModels
{
    public class ListBlockViewModel
    {
        public List<IListItem> Items { get; set; }

        public string Layout { get; set; }
    }
}