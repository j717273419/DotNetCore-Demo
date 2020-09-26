using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.FileExtensions;
using System.IO;

namespace ConsoleApp_Load_Deug_Release
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var environmentName = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT_Demo");
            if (string.IsNullOrWhiteSpace(environmentName))
            {
                Console.WriteLine($"当前的环境未配置");
            }
            Console.WriteLine($"当前的环境是{environmentName}");
            var a = Environment.GetEnvironmentVariables();
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.{environmentName}.json", false, true)
            .Build();
            //单值配置
            //"msg": "dev msg",
            var SingleValue = configuration.GetValue<string>("msg");
            Console.WriteLine($"{SingleValue}");
            //对象配置
            //"obj": {
            //  "foo": "dev bar"
            //}
            var obj = configuration.GetValue<string>("obj:foo");
            Console.WriteLine($"{obj}");
            Console.ReadKey();
        }
    }

    public class Demo
    {
        public string msg { get; set; }
    }
}
