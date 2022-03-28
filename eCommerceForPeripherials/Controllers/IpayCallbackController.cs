//using BankOfGeorgia.IpayClient;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace eCommerceForPeripherials.Controllers
//{
//    public class IpayCallbackController : Controller
//    {
//        private readonly IBankOfGeorgiaIpayClient _iPayClient;

//        public IpayCallbackController(IBankOfGeorgiaIpayClient iPayClient)
//        {
//            _iPayClient = iPayClient;
//        }

//        [HttpPost]
//        [HttpGet]
//        public async Task<IActionResult> Payment([FromForm] PaymentCallbackResult result)
//        {
//            var kk = result;
//            throw new NotImplementedException();
//        }

//        [HttpPost]
//        [HttpGet]
//        public async Task<IActionResult> Refund([FromForm] RefundCallbackResult result)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
