using Microsoft.AspNetCore.Mvc;
using ShopCosmetic.Data.Interfaces;
using ShopCosmetic.Data.Models;
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
        [Route("Cosmetic/List")]
        [Route("Cosmetic/List/{category}")]
         public ViewResult List(string category)
        {

            string _category = category;
            IEnumerable<Cosmetic> cosmetics=null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
                cosmetics = _allcosmetic.Cosmetics.OrderBy(i => i.CosmeticId);
            else
            {
                if (string.Equals("makeup", category, StringComparison.OrdinalIgnoreCase))
                {
                    cosmetics = _allcosmetic.Cosmetics.Where(i => i.Category.CategoryName.Equals("Макияж")).OrderBy(i => i.CosmeticId);
                    currCategory = "Макияж";
                }
                else if (string.Equals("hair", category, StringComparison.OrdinalIgnoreCase))
                {
                    cosmetics = _allcosmetic.Cosmetics.Where(i => i.Category.CategoryName.Equals("Уход за волосами")).OrderBy(i => i.CosmeticId);
                    currCategory = "Уход за волосами";
                }

                else if (string.Equals("body", category, StringComparison.OrdinalIgnoreCase))
                {
                    cosmetics = _allcosmetic.Cosmetics.Where(i => i.Category.CategoryName.Equals("Уход для тела")).OrderBy(i => i.CosmeticId);
                    currCategory = "Уход для тела";
                }

                else if (string.Equals("face", category, StringComparison.OrdinalIgnoreCase))
                {
                    cosmetics = _allcosmetic.Cosmetics.Where(i => i.Category.CategoryName.Equals("Уход для лица")).OrderBy(i => i.CosmeticId);
                    currCategory = "Уход для лица";
                }


                }
            var cosmeticObj = new CosmeticListViewModel
            {
                AllCosmetics = cosmetics,
                CurrCategory = currCategory
            };
            ViewBag.Title="Страница с косметикой";
         
            return View(cosmeticObj);
        }
    }
}
