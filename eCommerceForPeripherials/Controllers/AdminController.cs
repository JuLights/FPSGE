using eCommerceForPeripherials.Data;
using eCommerceForPeripherials.Models;
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

            return View();
        }

        [HttpPost]
        public IActionResult DeleteItem(int? Id)
        {
            var obj = _db.Items.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Items.Remove(obj);
            _db.SaveChanges();

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
        public IActionResult EditItem(Item item)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Update(item);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult CreateItem(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();

            return RedirectToAction("Index","Home");
        }

    }
}
