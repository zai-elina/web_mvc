using Microsoft.AspNetCore.Mvc;
using ShopCosmetic.Data.Interfaces;
using ShopCosmetic.Data.Models;
using ShopCosmetic.Data.Repository;
using ShopCosmetic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.Controllers
{
    public class ShoppingCartController: Controller
    {
        private readonly ICosmetic _cosmeticRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ICosmetic cosmeticRepository, ShoppingCart shoppingCart)
        {
           _cosmeticRepository = cosmeticRepository;
            _shoppingCart = shoppingCart;
        }


        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var obj = new ShoppingCartViewModel
            {
                shoppingCart = _shoppingCart
               
            };
            return View(obj);
        }
        public RedirectToActionResult AddToShoppingCart(int cosmeticId)
        {
            var selectedCosmetic = _cosmeticRepository.Cosmetics.FirstOrDefault(p => p.CosmeticId ==cosmeticId);
            if (selectedCosmetic != null)
            {
                _shoppingCart.AddToCart(selectedCosmetic);
            }
            return RedirectToAction("Index");
        }

        

    }
}
