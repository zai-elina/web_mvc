using ShopCosmetic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.ViewModels
{
    public class CosmeticListViewModel
    {
        public IEnumerable<Cosmetic> AllCosmetics { get; set; }

        public string CurrCategory{get;set;}

    }
}
