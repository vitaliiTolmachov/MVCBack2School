using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace _3_02_NetCoreHttpHandler.Middleware
{
    public class MyHandlerMiddleware
    {
        // Must have constructor with this signature, otherwise exception at run time
        public MyHandlerMiddleware(RequestDelegate next)
        {
            // This is an HTTP Handler, so no need to store next
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("<p>.Net Core is awesome!</p>");
        }
    }
}
