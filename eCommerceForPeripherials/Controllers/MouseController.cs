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
        private readonly IApplicationDbContext _db;

        public MouseController(IApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            TempData["Mouse"] = "active";

            IEnumerable<Item> itemList = _db.Items.Where(x => x.ItemName == "Mouse");

            //Correct way of doing this!!!

            //IEnumerable<Item> itemList = _db.Items;
            //var mouseList = from item in itemList
            //                where item.ItemName == "Mouse"
            //                orderby item.Id descending
            //                select item;

            //return View(mouseList);




            return View(itemList.OrderByDescending(x => x.Id).ToList());
            
        }

    }
}
