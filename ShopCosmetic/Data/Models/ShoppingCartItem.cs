using ShopCosmetic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.Data.Models
{
    public class ShoppingCartItem
    {
        
        public int ShoppingCartItemId { get; set; }
         public Cosmetic Cosmetic{ get; set; }
        public decimal Price { get; set; }
        public string ShoppingCartId { get; set; }
        
    }
}
