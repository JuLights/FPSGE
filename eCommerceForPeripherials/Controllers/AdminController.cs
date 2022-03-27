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
        public async Task<IActionResult> DeleteItem(int? Id)
        {
            var obj = await _db.Items.FindAsync(Id);
            if (obj == null)
            {
                return NotFound();
            }
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
            if (ModelState.IsValid)
            {
                _db.Items.Update(item);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(Item item)
        {
            await _db.Items.AddAsync(item);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index","Home");
        }

    }
}
