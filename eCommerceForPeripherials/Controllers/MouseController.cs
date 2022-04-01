using eCommerceForPeripherials.Data;
using eCommerceForPeripherials.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Controllers
{
    public class MouseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MouseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            TempData["Mouse"] = "active";

            IEnumerable<Item> itemList = _db.Items.Where(x=>x.ItemName == "Mouse");

            return View(itemList.OrderByDescending(x => x.Id));
        }

    }
}
