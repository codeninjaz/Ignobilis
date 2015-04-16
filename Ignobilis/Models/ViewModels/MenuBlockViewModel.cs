using System;
using System.Collections.Generic;

namespace Ignobilis.Models.ViewModels
{
    public class MenuBlockViewModel
    {
        public Guid BlockGuid { get; set; }
        public List<int> ChildrenFrom { get; set; }
        public List<int> Pages { get; set; }
    }
}