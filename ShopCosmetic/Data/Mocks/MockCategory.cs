using ShopCosmetic.Data.Interfaces;
using ShopCosmetic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.Data.Mocks
{
    public class MockCategory : ICosmeticCategory
    {
        public IEnumerable<Category> AllCategories {
            get
            {
                return new List<Category>
                {
                     new Category { CategoryName = "Уход для лицом", Description = "Все товары категории" },
                     new Category { CategoryName = "Уход для телом ", Description = "Все товары категории" },
                     new Category { CategoryName = "Уход для волосами ", Description = "Все товары категории" },
                      new Category { CategoryName = "Макияж ", Description = "Все товары категории" }

                };
            }
        }
        
    }
}
