using Microsoft.AspNetCore.Mvc;
using ShopCosmetic.Data.Interfaces;
using ShopCosmetic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShopCosmetic.Controllers
{
    public class OrderController:Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IAllOrders allOrders, ShoppingCart shoppingCart)
        {
            _allOrders=allOrders;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            if(_shoppingCart.ShoppingCartItems.Count==0)
            {
                ModelState.AddModelError("","У вас должны быть товары");
            }

            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ завершен успешно";
            return View();
        }
    }
}
