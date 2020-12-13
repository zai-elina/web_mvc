using ShopCosmetic.Data.Interfaces;
using ShopCosmetic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.Data.Mocks
{
    public class MockCosmetic : ICosmetic
    {
        private readonly ICosmeticCategory _categoryCosmetics = new MockCategory();
        public IEnumerable<Cosmetic> Cosmetics {
            get
            {
                return new List<Cosmetic>
                {
                    new Cosmetic
                    {
                        Name = "Тушь",
                        Price =100, ShortDescription = "",
                        LongDescription = "",
                        Category =  _categoryCosmetics. AllCategories.First(p=>p.CategoryName.StartsWith("M")),
                        Image = " ",
                        InStock = true,
                        IsPreferredCosmetic = true
                    }
                };
            }
        
        }
        public IEnumerable<Cosmetic> PreferredCosmetics { get ; set ; }

        public Cosmetic GetCosmeticById(int cosmeticId)
        {
            throw new NotImplementedException();
        }
    }
}
