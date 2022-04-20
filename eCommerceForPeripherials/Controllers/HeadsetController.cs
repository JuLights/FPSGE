using eCommerceForPeripherials.Data;
using eCommerceForPeripherials.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Controllers
{
    public class HeadsetController : Controller
    {
        private readonly IApplicationDbContext _db;
        public HeadsetController(IApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            TempData["Headset"] = "active";
            IEnumerable<Item> itemList = _db.Items.Where(x => x.ItemName == "Headset");

            return View(itemList.OrderByDescending(x => x.Id).ToList());
        }
    }
}
