using ShopCosmetic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Cosmetic> preferredCosmetic { get; set; }
    }
}
