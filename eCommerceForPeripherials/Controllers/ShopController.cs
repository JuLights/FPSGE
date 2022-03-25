using BankOfGeorgia.IpayClient;
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
        private readonly IBankOfGeorgiaIpayClient _iPayClient; //iPay
        public ShopController(ApplicationDbContext db, IBankOfGeorgiaIpayClient iPayClient)
        {
            _db = db;
            _iPayClient = iPayClient;
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

        public async Task<IActionResult> Checkout(int? Id)
        {
            var checkoutItem = _db.Items.Where(x => x.Id == Id).FirstOrDefault();
            string prdctId = checkoutItem.Id.ToString();

            var orderItem = new List<OrderItem>();
            orderItem.Add(new OrderItem
            {
                Price = Convert.ToDecimal(checkoutItem.Price),
                Description = checkoutItem.Description,
                ProductId = checkoutItem.Id.ToString(),
                Quantity = 1
            });

            //await _iPayClient.AuthenticateAsync(); //es aucilebelia

            var shporderid = checkoutItem.Name + "//" + checkoutItem.Brand + "//" + checkoutItem.Id.ToString();
            var response = await _iPayClient.MakeOrderAsync(new OrderRequest
            {
                Intent = Intent.Capture,
                CaptureMethod = CaptureMethod.Automatic,
                Currency = IPayCurrency.GEL,
                Items = orderItem,
                Locale = Locale.KA,
                ShopOrderId = checkoutItem.Name + "//" + checkoutItem.Brand + "//" + checkoutItem.Id.ToString(),
                 ShowShopOrderIdOnExtract = true,
                 RedirectUrl = $"https://demo.ipay.ge?shop_order_id={shporderid}",
            });
            var redirectUrl = $"https://demo.ipay.ge?shop_order_id={shporderid}"; // responsedan unda mivigo GetRedirectUrl(); metodit

            return Redirect(redirectUrl);
        }
    }
}
