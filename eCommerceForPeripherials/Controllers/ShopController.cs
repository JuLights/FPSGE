//using BankOfGeorgia.IpayClient;
using eCommerceForPeripherials.Data;
using eCommerceForPeripherials.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _db;
        //private readonly IBankOfGeorgiaIpayClient _iPayClient; //iPay
        public ShopController(ApplicationDbContext db/*, IBankOfGeorgiaIpayClient iPayClient*/)
        {
            _db = db;
            //_iPayClient = iPayClient;
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
            //var checkoutItem = _db.Items.Where(x => x.Id == Id).FirstOrDefault();

            //var order = new OrderRequest()
            //{
            //    Intent = Intent.Authorize,
            //    Currency = IPayCurrency.GEL,
            //    Items = new[]
            //    {
            //        new OrderItem() { Price= Convert.ToDecimal(checkoutItem.Price), Description = checkoutItem.Description, Quantity = 1, ProductId = checkoutItem.Id.ToString() }
            //    },
            //    Locale = "ka",
            //    ShopOrderId = Guid.NewGuid().ToString("N"),
            //    //RedirectUrl = "https://localhost:44371//IpayCallback/Payment", //dev
            //    RedirectUrl = "https://fps.ge//IpayCallback/Payment", //prod
            //    ShowShopOrderIdOnExtract = true,
            //    CaptureMethod = CaptureMethod.Automatic,
            //};

            ////await _iPayClient.AuthenticateAsync();

            ////await _iPayClient.AuthenticateAsync(); //es aucilebelia

            ////var shporderid = checkoutItem.Name + "//" + checkoutItem.Brand + "//" + checkoutItem.Id.ToString();
            //var response = await _iPayClient.MakeOrderAsync(order);

            // When succeeded redirect to bank page
            //var redirectUrl = response.GetRedirectUrl();

            return View(/*redirectUrl*/);
        }

        //public async Task<RedirectResult> BogPayment(int Id)
        //{
        //    var checkoutItem = _db.Items.Where(x => x.Id == Id).FirstOrDefault();

        //    var order = new OrderRequest()
        //    {
        //        Intent = Intent.Authorize,
        //        Currency = IPayCurrency.GEL,
        //        Items = new[]
        //        {
        //            new OrderItem() { Price= Convert.ToDecimal(checkoutItem.Price), Description = checkoutItem.Description, Quantity = 1, ProductId = checkoutItem.Id.ToString() }
        //        },
        //        Locale = "ka",
        //        ShopOrderId = Guid.NewGuid().ToString("N"),
        //        //RedirectUrl = "https://localhost:44371//IpayCallback/Payment", //dev
        //        RedirectUrl = "https://fps.ge//IpayCallback/Payment", //prod
        //        ShowShopOrderIdOnExtract = true,
        //        CaptureMethod = CaptureMethod.Automatic,
        //    };


        //    var response = await _iPayClient.MakeOrderAsync(order);
        //    var redirectUrl = response.GetRedirectUrl();

        //    return Redirect(redirectUrl);
        //}


    }
}
