using ShopCosmetic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.Data.Interfaces
{
   public interface ICosmetic
    {
        IEnumerable<Cosmetic> Cosmetics { get;  }
        IEnumerable<Cosmetic> PreferredCosmetics { get; set; }
        Cosmetic GetCosmeticById(int cosmeticId);
    }
}
