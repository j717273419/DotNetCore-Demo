using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace aspnet_core_webapi_002.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public string Now { get; set; }
        public UserController(IConfiguration configuration)
        {
            var configWeChat = configuration["WeChatVersion"];
            Now = configWeChat;
        }
        [HttpGet]
        public string Get()
        {
            return Now;
        }
    }
}
