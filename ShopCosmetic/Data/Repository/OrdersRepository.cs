using ShopCosmetic.Data.Interfaces;
using ShopCosmetic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrdersRepository(AppDBContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;

            _appDbContext.Order.Add(order);
            _appDbContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    
                    CosmeticId = shoppingCartItem.Cosmetic.CosmeticId,
                    OrderId = order.Id,
                    Price = shoppingCartItem.Cosmetic.Price
                };

                _appDbContext.OrderDetail.Add(orderDetail);
            }

            
        }
    }
}
