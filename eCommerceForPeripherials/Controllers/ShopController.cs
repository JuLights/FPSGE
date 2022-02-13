using eCommerceForPeripherials.Data;
using eCommerceForPeripherials.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ShopController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Details(int? Id)
        {
            var item = _db.Items.Where(x => x.Id == Id).FirstOrDefault();

            return View(item);
        }

        //[HttpPost]
        public IActionResult AddToCart(int? Id)
        {
            var itemToSell = _db.Items.Where(x => x.Id == Id).FirstOrDefault();

            return View(itemToSell);
        }

        public IActionResult Checkout(int? Id)
        {
            var checkoutItem = _db.Items.Where(x => x.Id == Id).FirstOrDefault();

            return View(checkoutItem);
        }
    }
}
