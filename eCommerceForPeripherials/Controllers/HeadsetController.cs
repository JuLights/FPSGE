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
        private readonly ApplicationDbContext _db;
        public HeadsetController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> itemList = _db.Items.Where(x => x.ItemName == "Headset");

            return View(itemList.OrderByDescending(x => x.Id));
        }
    }
}
