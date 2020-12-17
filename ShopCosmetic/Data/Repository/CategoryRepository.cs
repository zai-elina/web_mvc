using ShopCosmetic.Data.Interfaces;
using ShopCosmetic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.Data.Repository
{
    public class CategoryRepository : ICosmeticCategory
    {
        private readonly AppDBContext appDbContent;
        public CategoryRepository(AppDBContext appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<Category> AllCategories => appDbContent.Category;
    }
}
