using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace eCommerceForPeripherials.Utility
{
    public class VisitorCounterMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public static string _visitorId;
        public VisitorCounterMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string visitorId = context.Request.Cookies["VisitorId"];
            if (visitorId == null)
            {
                //don the necessary staffs here to save the count by one

                context.Response.Cookies.Append("VisitorId", Guid.NewGuid().ToString(), new CookieOptions()
                {
                    Path = "/",
                    HttpOnly = true,
                    Secure = false,
                });

                _visitorId = context.Request.Cookies["VisitorId"];
            }

            await _requestDelegate(context);
        }
    }
}
