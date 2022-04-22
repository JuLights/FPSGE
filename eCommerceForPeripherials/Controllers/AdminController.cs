using eCommerceForPeripherials.Data;
using eCommerceForPeripherials.Models;
using eCommerceForPeripherials.Models.Admin;
using eCommerceForPeripherials.Models.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        //login
        public IActionResult Index()
        {
            return View();
        }

        //[filter]
        //add item in db method
        public IActionResult CreateItem()
        {
            ViewBag.Response = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int? Id)
        {
            var obj = await _db.Items.FindAsync(Id);
            if (obj == null)
            {
                return NotFound();
            }
            var itemForDeleteId = _db.Items.ToList().LastOrDefault().Id;
            await _db.LastItemIds.AddAsync(new LastItemIds { LastItemId = itemForDeleteId }); //!!!important
            _db.Items.Remove(obj);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> EditItem(int? Id)
        {
            var itemForEdit = await _db.Items.FindAsync(Id);
            if (itemForEdit != null)
            {
                return View(itemForEdit);
            }

            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditItem(Item item)
        {
            var gearLink = new GearLinkHelper();
            string response = "";


            if (ModelState.IsValid)
            {
                if (item.ItemName.ToLower() == "headset")
                {
                    response = await gearLink.CheckAndAddHeadsetInPros(item, _db, "edit");
                }

                if (item.ItemName.ToLower() == "keyboard")
                {
                    response = await gearLink.CheckAndAddKeyboardInPros(item, _db, "edit");
                }
                if (item.ItemName.ToLower() == "mouse")
                {
                    response = await gearLink.CheckAndAddMouseInPros(item, _db, "edit");
                }

                TempData["affected"] = response;
                var itemForEdit = await _db.Items.FindAsync(item.Id);

                itemForEdit.RGB = item.RGB;
                itemForEdit.Connection = item.Connection;
                itemForEdit.Name = item.Name;
                itemForEdit.Description = item.Description;
                itemForEdit.ItemCondition = item.ItemCondition;
                itemForEdit.Brand = item.Brand;
                itemForEdit.CableLength = item.CableLength;
                itemForEdit.Colour = item.Colour;
                itemForEdit.Connection=item.Connection;
                itemForEdit.ItemImageUrl= item.ItemImageUrl;
                itemForEdit.Wireless= item.Wireless;
                itemForEdit.ItemName = item.ItemName;
                itemForEdit.Price= item.Price;
                itemForEdit.ViewCount= item.ViewCount;

                if(itemForEdit != null)
                {
                    _db.Items.Update(itemForEdit);
                    await _db.SaveChangesAsync();
                }
                
                return View("ItemAddedResponse", TempData["affected"]);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(Item item)
        {
            var gearLink = new GearLinkHelper();
            string response = "";

            await _db.Items.AddAsync(item);
            _db.SaveChanges();

            await _db.LastItemIds.AddAsync(new LastItemIds { LastItemId = _db.Items.ToList().LastOrDefault().Id });
            await _db.SaveChangesAsync();

            if (item.ItemName.ToLower() == "headset")
            {
                response = await gearLink.CheckAndAddHeadsetInPros(item, _db, "add");
            }

            if (item.ItemName.ToLower() == "keyboard")
            {
                response = await gearLink.CheckAndAddKeyboardInPros(item, _db, "add");
            }
            if (item.ItemName.ToLower() == "mouse")
            {
                response = await gearLink.CheckAndAddMouseInPros(item, _db, "add");
            }

            TempData["affected"] = response;

            //ViewBag["affected"] = response;

            

            return View("ItemAddedResponse", TempData["affected"]);
            //return RedirectToAction("Index","Home");
        }


        [HttpGet]
        public IActionResult ProductsUSD()
        {

            var products = _db.Products.ToList();

            //await _db.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Products product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

            return RedirectToAction("Products","Admin");
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int? Id)
        {
            var productForEdit = await _db.Products.FindAsync(Id);
            if (productForEdit != null)
            {
                return View(productForEdit);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Products product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Products","Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int? Id)
        {
            //var productForDel =  _db.Products.Where(x => x.Id == Id).FirstOrDefault();
            //_db.Products.Remove(productForDel);

            var prdForDelete = await _db.Products.FindAsync(Id);
            if (prdForDelete == null)
            {
                return NotFound();
            }
            _db.Products.Remove(prdForDelete);
            await _db.SaveChangesAsync();

            return RedirectToAction("Products", "Admin");
        }

        [HttpGet]
        public IActionResult ProductsGEL()
        {

            var products = _db.productsGELs.ToList();
            //await _db.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult CreateProductGEL()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductGEL(ProductsGEL product)
        {
            await _db.productsGELs.AddAsync(product);
            await _db.SaveChangesAsync();

            return RedirectToAction("ProductsGEL", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> EditProductGEL(int? Id)
        {
            var productForEdit = await _db.productsGELs.FindAsync(Id);
            if (productForEdit != null)
            {
                return View(productForEdit);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProductGEL(ProductsGEL product)
        {
            if (ModelState.IsValid)
            {
                _db.productsGELs.Update(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("ProductsGEL", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProductGEL(int? Id)
        {
            //var productForDel =  _db.Products.Where(x => x.Id == Id).FirstOrDefault();
            //_db.Products.Remove(productForDel);

            var prdForDelete = await _db.productsGELs.FindAsync(Id);
            if (prdForDelete == null)
            {
                return NotFound();
            }
            _db.productsGELs.Remove(prdForDelete);
            await _db.SaveChangesAsync();

            return RedirectToAction("ProductsGEL", "Admin");
        }


    }
}
