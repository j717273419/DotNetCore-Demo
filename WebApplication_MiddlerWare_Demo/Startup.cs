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
 �����м��
ASP.NET Core���������м�������

�м��	����
Authentication	�ṩ�����֤֧��
CORS	���ÿ�����Դ����
Response Caching	�ṩ������Ӧ֧��
Response Compression	�ṩ��Ӧѹ��֧��
Routing	�����Լ������·��
Session	�ṩ�û��Ự����
Static Files	Ϊ��̬�ļ���Ŀ¼����ṩ�����ṩ֧��
URL Rewriting Middleware	������д Url�����������ض����֧��
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
            //    await context.Response.WriteAsync("�����һ��ί�� ִ����һ��ί��֮ǰ\r\n");
            //    //���ùܵ��е���һ��ί��
            //    await next.Invoke();
            //    await context.Response.WriteAsync("������һ��ί�� ִ����һ��ί��֮��\r\n");
            //});
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("����ڶ���ί��\r\n");
            //    await context.Response.WriteAsync("Hello from 2nd delegate.\r\n");
            //    await context.Response.WriteAsync("�����ڶ���ί��\r\n");
            //});

            /*
             *
                �����һ��ί�� ִ����һ��ί��֮ǰ
                ����ڶ���ί��
                Hello from 2nd delegate.
                �����ڶ���ί��
                ������һ��ί�� ִ����һ��ί��֮��
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
