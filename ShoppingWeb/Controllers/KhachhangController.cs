using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingWeb.Helpers;
using ShoppingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWeb.Controllers
{
    public class KhachhangController : Controller
    {
        private WEBBANHANGContext db = new WEBBANHANGContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string sdt, string pwd)
        {
            var account = db.Khachhangs.ToList();
            foreach (var item in account)
            {
                if (sdt != null && pwd != null && sdt.Equals(item.SdtKh) && pwd.Equals(item.MatKhau))
                {
                    HttpContext.Session.SetString("sdt", sdt);
                    return View("thanhcong");
                }
                else
                {
                    ViewBag.eror = "Sai tên tài khoản hoặc mật khẩu";
                }
            }
            return View("Index");
        }
        public IActionResult thanhcong()
        {
            return View();
        }
        public Khachhang getDetailKhachHang(int sdt)
        {
            var cus = db.Khachhangs.Find(sdt);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cus);
            return cus;
        }
    }
}
