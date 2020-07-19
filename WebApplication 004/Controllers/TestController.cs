using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_core_webapi_002.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        public string Now { get; set; }
        public TestController(string configWechat)
        {
            Now = configWechat;
        }
        [HttpGet]
        public string Get()
        {
            return Now;
        }
    }
}
