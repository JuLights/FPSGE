using BankOfGeorgia.IpayClient;
using eCommerceForPeripherials.Data;
using eCommerceForPeripherials.Models;
using eCommerceForPeripherials.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Controllers
{
    
    //[Authorize(Roles = "Admin")]
    public class ShopController : Controller
    {
        private static Object payLock = new object();


        private readonly IApplicationDbContext _db;
        private readonly IBankOfGeorgiaIpayClient _iPayClient; //iPay
        public ShopController(IApplicationDbContext db, IBankOfGeorgiaIpayClient iPayClient)
        {
            _db = db;
            _iPayClient = iPayClient;
        }

        public IActionResult Details(int? Id)
        {
            var item = _db.Items.Where(x => x.Id == Id).FirstOrDefault();

            //VisitorCounterMiddleware._visitorId

            string visitorId = HttpContext.Request.Cookies["VisitorId"];


            if (visitorId != null)
            {

            }

            return View(item);
        }

        //[HttpPost]
        [Authorize(Roles = "User,Admin")]
        public IActionResult AddToCart(int? Id)
        {
            var itemToSell = _db.Items.Where(x => x.Id == Id).FirstOrDefault();

            return View(itemToSell);
        }

        [Authorize(Roles = "User,Admin")]
        public IActionResult Checkout(int? Id)
        {
            var checkoutItem = _db.Items.Where(x => x.Id == Id).FirstOrDefault();

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

            return View(checkoutItem);
            //return Redirect(/*redirectUrl*/);
        }

        [Authorize(Roles = "User,Admin")]
        public async Task<RedirectResult> IPayment(int Id)
        {
            var checkoutItem = _db.Items.Where(x => x.Id == Id).FirstOrDefault();

            var order = new OrderRequest()
            {
                Intent = Intent.Capture,
                Currency = IPayCurrency.GEL,
                Items = new[]
                {
                    new OrderItem() { Price= Convert.ToDecimal(checkoutItem.Price), Description = checkoutItem.Description, Quantity = 1, ProductId = checkoutItem.Id.ToString() }
                },
                Locale = "ka",
                ShopOrderId = Guid.NewGuid().ToString("N"),
                //RedirectUrl = "https://localhost:44371//IpayCallback/Payment", //dev
                RedirectUrl = "https://fps.ge//IpayCallback/Payment", //prod
                ShowShopOrderIdOnExtract = true,
                CaptureMethod = CaptureMethod.Automatic,
            };

            var response = await _iPayClient.MakeOrderAsync(order);
            var redirectUrl = response.GetRedirectUrl();
            //string redir = "";
            //Thread payThread = new Thread(async () =>
            //{
            //    redir = await PayWithIPay(order);
            //});

            

            //lock (payLock)
            //{
            //    payThread.Start();
            //    //Thread.Sleep(30000);
            //}


            return Redirect(redirectUrl);
        }


        //public async Task<string> PayWithIPay(OrderRequest order)
        //{
        //    var response = await _iPayClient.MakeOrderAsync(order);
        //    var redirectUrl = response.GetRedirectUrl();
        //    return redirectUrl;
        //}


    }
}
