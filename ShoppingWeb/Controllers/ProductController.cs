using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(ILogger<ProductController> logger, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            this._hostEnvironment = hostEnvironment;
        }
        private WEBBANHANGContext db = new WEBBANHANGContext();


        [Route("product")]
        public IActionResult index()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.DienThoai = productModel.DSSP();
            return View();
        }
        public IActionResult list()             // Danh sách thêm sửa xóa
        {
            ProductModel productModel = new ProductModel();
            ViewBag.DienThoai = productModel.DSSP();
            return View();
        }
        #region Danh sách điện thoại
        [Route("product/iphone")]
        public IActionResult iphone()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.DienThoai = productModel.DSiPhone();
            return View();
        }

        public IActionResult samsung()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.DienThoai = productModel.dsSamsung();
            return View();
        }
        public IActionResult vsmart()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.DienThoai = productModel.dsVsmart();
            return View();
        }
        public IActionResult xiaomi()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.DienThoai = productModel.dsXiaomi();
            return View();
        }
        public IActionResult huawei()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.DienThoai = productModel.dsHuawei();
            return View();
        }
        #endregion

         //Danh sách Máy tính bảng
        public IActionResult tablet()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.tablet = productModel.tablet();
            return View();
        }

        // Danh sach laptop
        public IActionResult laptop()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.laptop = productModel.laptop();
            return View();
        }
        public IActionResult macbook()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.macbook = productModel.macbook();
            return View();
        }
        #region CRUD
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sanpham products)
        {
            if (ModelState.IsValid)
            {
                string rootpath = _hostEnvironment.WebRootPath;
                string fileName;
                string ext = Path.GetExtension(products.imageFile.FileName);
                products.HinhSp = fileName = products.TenSp + ext;
                string path = Path.Combine(rootpath + "/image/", fileName);
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    products.imageFile.CopyTo(fs);
                }


                db.Add(products);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(list));
            }
            return View(products);
        }
        

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await db.Sanphams
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await db.Sanphams.FindAsync(id);
            db.Sanphams.Remove(products);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(list));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await db.Sanphams
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }


        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var products = await db.Sanphams.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Sanpham products)
        {
            if (id != products.MaSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    string rootpath = _hostEnvironment.WebRootPath;
                    string fileName;
                    string ext = Path.GetExtension(products.imageFile.FileName);
                    products.HinhSp = fileName = products.TenSp + ext;
                    string path = Path.Combine(rootpath + "/image/", fileName);
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        products.imageFile.CopyTo(fs);
                    }

                    db.Update(products);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.MaSp))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(list));
            }
            return View(products);
        }


        private bool ProductsExists(int? id)
        {
            return db.Sanphams.Any(e => e.MaSp == id);
        }
#endregion
    }
}
