using ShopCosmetic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.Data.Interfaces
{
    public interface ICosmeticCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
