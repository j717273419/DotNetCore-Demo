using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_ResourceFilter.Filter
{
    public class ResourceFilterDemo : Attribute, IResourceFilter
    {
        /*
         * Resource Filter 执行顺序
         *
            OnResourceExecuting
            HomeController
            IActionResult Index
            OnResourceExecuted
         *
         */
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("OnResourceExecuting");
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("OnResourceExecuted");
        }

    }
}
