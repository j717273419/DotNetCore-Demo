﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_webapi_002.Services
{
    public interface IClock
    {
        public DateTime Now();
    }
}
