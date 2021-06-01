using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWeb.Controllers
{
    public class HomeController : Controller
    {
        private WEBBANHANGContext db = new WEBBANHANGContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.DienThoai = productModel.DSSP();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
