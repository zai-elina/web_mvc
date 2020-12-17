using Microsoft.EntityFrameworkCore;
using ShopCosmetic.Data.Interfaces;
using ShopCosmetic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.Data.Repository
{
    public class CosmeticRepository : ICosmetic
    {
        private readonly AppDBContext appDbContent;
        public CosmeticRepository(AppDBContext appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Cosmetic> Cosmetics => appDbContent.Cosmetic.Include(c =>c.Category);
        public IEnumerable<Cosmetic> PreferredCosmetics => appDbContent.Cosmetic.Where(s => s.IsPreferredCosmetic).Include(c => c.Category);

        public Cosmetic GetCosmeticById(int cosmeticId) => appDbContent.Cosmetic.FirstOrDefault(a => a.CosmeticId ==cosmeticId);
    }
}
