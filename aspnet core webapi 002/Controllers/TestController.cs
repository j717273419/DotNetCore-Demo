using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_webapi_002.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_core_webapi_002.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        public DateTime Now { get; set; }
        public TestController(IClock clock)
        {
            Now = clock.Now();
        }
        [HttpGet]
        public string Get()
        {
            return Now.ToString();
        }
    }
}
