using Microsoft.AspNetCore.Mvc;
using ShopCosmetic.Data.Interfaces;
using ShopCosmetic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.Controllers
{
    public class CosmeticController: Controller
    {
        private readonly ICosmetic _allcosmetic;
        private readonly ICosmeticCategory _allcategories;

        public CosmeticController(ICosmetic allcosmetic, ICosmeticCategory allcategories)
        {
            _allcosmetic = allcosmetic;
            _allcategories = allcategories;
        }

         public ViewResult List()
        {
            ViewBag.Title="Страница с косметикой";
            CosmeticListViewModel obj =new CosmeticListViewModel();
            obj.AllCosmetics = _allcosmetic.Cosmetics;
            obj.CurrCategory = "Косметика";
            return View(obj);
        }
    }
}
