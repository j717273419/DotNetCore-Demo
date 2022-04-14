using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_MiddlerWare_Demo.MiddleWare;

/*
 * asp.net core middleware demo
 *
 * https://blog.csdn.net/weixin_34405354/article/details/85951646?utm_medium=distribute.pc_relevant.none-task-blog-2%7Edefault%7EBlogCommendFromMachineLearnPai2%7Edefault-1.control&depth_1-utm_source=distribute.pc_relevant.none-task-blog-2%7Edefault%7EBlogCommendFromMachineLearnPai2%7Edefault-1.control
 *
 *
 *
 内置中间件
ASP.NET Core附带以下中间件组件：

中间件	描述
Authentication	提供身份验证支持
CORS	配置跨域资源共享
Response Caching	提供缓存响应支持
Response Compression	提供响应压缩支持
Routing	定义和约束请求路由
Session	提供用户会话管理
Static Files	为静态文件和目录浏览提供服务提供支持
URL Rewriting Middleware	用于重写 Url，并将请求重定向的支持
 */
namespace WebApplication_MiddlerWare_Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseMiddleware<SingMiddleWares>();

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello, World!");
            //});


            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("进入第一个委托 执行下一个委托之前\r\n");
            //    //调用管道中的下一个委托
            //    await next.Invoke();
            //    await context.Response.WriteAsync("结束第一个委托 执行下一个委托之后\r\n");
            //});
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("进入第二个委托\r\n");
            //    await context.Response.WriteAsync("Hello from 2nd delegate.\r\n");
            //    await context.Response.WriteAsync("结束第二个委托\r\n");
            //});

            /*
             *
                进入第一个委托 执行下一个委托之前
                进入第二个委托
                Hello from 2nd delegate.
                结束第二个委托
                结束第一个委托 执行下一个委托之后
             *
             */

            //app.Map("/map1", HandleMapTest1);

            //app.Map("/map2", HandleMapTest2);

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("<p>Hello from non-Map delegate. <p>");
            //});

            //app.MapWhen(context => context.Request.Query.ContainsKey("branch"),
            //                   HandleBranch);

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from non-Map delegate. <p>");
            //});

            app.UseRequestCulture();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    $"Hello {CultureInfo.CurrentCulture.DisplayName}");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void HandleMapTest1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
            });
        }

        private static void HandleMapTest2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 2");
            });
        }

        private static void HandleBranch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var branchVer = context.Request.Query["branch"];
                await context.Response.WriteAsync($"Branch used = {branchVer}");
            });
        }


    }
}
