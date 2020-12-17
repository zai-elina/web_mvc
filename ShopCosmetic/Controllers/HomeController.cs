using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopCosmetic.Data.Interfaces;
using ShopCosmetic.ViewModels;

namespace ShopCosmetic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICosmetic _cosmeticRepository;
     
        public HomeController(ICosmetic cosmeticRepository)
        {
            _cosmeticRepository = cosmeticRepository;
        }
        public ViewResult Index()
        {
            var homeCosmetic = new HomeViewModel
            {
                preferredCosmetic= _cosmeticRepository.PreferredCosmetics

            };
            return View(homeCosmetic);
        }

    }
}
