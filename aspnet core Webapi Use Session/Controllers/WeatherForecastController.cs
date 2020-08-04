using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspnet_core_Webapi_Use_Session.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet]
        [Route("/WeatherForecast/SessionTest")]
        public string GetSession()
        {
            HttpContext.Session.SetString("testsession", "wdjsession");
            return HttpContext.Session.GetString("testsession");
        }

        //POST /weatherforecast/sessionadd HTTP/1.1
        //Host: localhost:44321
        //Content-Type: application/json
        //User-Agent: PostmanRuntime/7.19.0
        //Accept: */*
        //Cache-Control: no-cache
        //Host: localhost:44321
        //Accept-Encoding: gzip, deflate
        //Content-Length: 10
        //Cookie: .AspNetCore.Session=CfDJ8MJ1Gnpw4ktOvnhMEF%2FmwJ6c6iI7kJuxcN9FuKVEpQWl409psPQSPyFoneJyk78JSoCPnZN7uS16FMDNkYsjULcYi%2FDjdGVBLdnuOjTlrP2SPFoFQo8%2BDpfQWu8%2BLA3BDq4Qk1wkDNG%2FNpSZ273TYSthY0OX%2BzZTs4rwpCNVHl6%2F
        //Connection: keep-alive
        //cache-control: no-cache
        //
        //"test0804"
        [HttpPost]
        [Route("/WeatherForecast/SessionAdd")]
        public string AddSession([FromBody] string key)
        {
            HttpContext.Session.SetString("testsession", key);
            return HttpContext.Session.GetString("testsession");
        }

        [HttpPost]
        [Route("/WeatherForecast/SessionAdd2")]
        public string AddSession2([FromBody] dynamic key)
        {
            string jsonstr = Convert.ToString(key);
            HttpContext.Session.SetString("testsession", jsonstr);
            return HttpContext.Session.GetString("testsession");
        }

        [HttpPost]
        [Route("/WeatherForecast/AddObj")]
        public string AddObj([FromBody] dynamic user)
        {
            string jsonstr = Convert.ToString(user);
            HttpContext.Session.SetString("testsession", jsonstr);
            return HttpContext.Session.GetString("testsession");
        }

        //POST /weatherforecast/sessionaddobj HTTP/1.1
        //Host: localhost:44321
        //Content-Type: application/json
        //User-Agent: PostmanRuntime/7.19.0
        //Accept: */*
        //Cache-Control: no-cache
        //Host: localhost:44321
        //Accept-Encoding: gzip, deflate
        //Content-Length: 32
        //Cookie: .AspNetCore.Session=CfDJ8MJ1Gnpw4ktOvnhMEF%2FmwJ6c6iI7kJuxcN9FuKVEpQWl409psPQSPyFoneJyk78JSoCPnZN7uS16FMDNkYsjULcYi%2FDjdGVBLdnuOjTlrP2SPFoFQo8%2BDpfQWu8%2BLA3BDq4Qk1wkDNG%2FNpSZ273TYSthY0OX%2BzZTs4rwpCNVHl6%2F
        //Connection: keep-alive
        //cache-control: no-cache
        //
        //{
        //	"UserName":"wdj",
        //	"Age":88
        //}
        //
        [HttpPost]
        [Route("/WeatherForecast/SessionAddObj")]
        public string AddSessionObj(User user)
        {
            var jsonstr = JsonSerializer.Serialize(user);
            HttpContext.Session.SetString("testsession", jsonstr);
            return HttpContext.Session.GetString("testsession");
        }

        //POST /weatherforecast/addform HTTP/1.1
        //Host: localhost:44321
        //Content-Type: application/json
        //User-Agent: PostmanRuntime/7.19.0
        //Accept: */*
        //Cache-Control: no-cache
        //Host: localhost:44321
        //Accept-Encoding: gzip, deflate
        //Content-Length: 34
        //Cookie: .AspNetCore.Session=CfDJ8MJ1Gnpw4ktOvnhMEF%2FmwJ6c6iI7kJuxcN9FuKVEpQWl409psPQSPyFoneJyk78JSoCPnZN7uS16FMDNkYsjULcYi%2FDjdGVBLdnuOjTlrP2SPFoFQo8%2BDpfQWu8%2BLA3BDq4Qk1wkDNG%2FNpSZ273TYSthY0OX%2BzZTs4rwpCNVHl6%2F
        //Connection: keep-alive
        //cache-control: no-cache
        //
        //{
        //	"UserName":"wdj3",
        //	"Age":333
        //}
        [HttpPost]
        [Route("/WeatherForecast/AddForm")]
        public string AddForm([FromBody]User user)
        {
            var jsonstr = JsonSerializer.Serialize(user);
            HttpContext.Session.SetString("testsession", jsonstr);
            return HttpContext.Session.GetString("testsession");
        }

        [HttpGet]
        [Route("/WeatherForecast/SessionGet")]
        public string GetSessionGet()
        {
            return HttpContext.Session.GetString("testsession");
        }

    }

    public class User
    {
        public string UserName { get; set; }
        public int Age { get; set; }
    }
}
