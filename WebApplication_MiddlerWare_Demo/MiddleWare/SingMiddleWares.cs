using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_MiddlerWare_Demo.MiddleWare
{
    public class SingMiddleWares
    {
        private RequestDelegate _next;
        public SingMiddleWares(RequestDelegate next)
        {
            Console.WriteLine("SingMiddleWares next");
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("SingMiddleWares InvokeAsync");
            //抛给下一个中间件
            //await _next(context);
            //或者报错
            // await context.Response.WriteAsync("error");
        }
    }
}
