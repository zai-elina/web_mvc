using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.Data.Models
{
    public class ShoppingCart
    {
        private readonly AppDBContext appDbContent;
        public ShoppingCart(AppDBContext appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public static ShoppingCart GetCart(IServiceProvider services)//добавляет товар в корзину, если первый товар, то создает новую корзину
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDBContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

      

        public void AddToCart(Cosmetic cosmetic)//добавляет товары в корзину
        {
            var shoppingCartItem =
                    appDbContent.ShoppingCartItem.SingleOrDefault(
                        s => s.Cosmetic.CosmeticId == cosmetic.CosmeticId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Cosmetic = cosmetic,
                    Price=cosmetic.Price
                };

                appDbContent.ShoppingCartItem.Add(shoppingCartItem);
            }
           
            appDbContent.SaveChanges();
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       appDbContent.ShoppingCartItem.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Cosmetic)
                           .ToList());
        }



    }
}
