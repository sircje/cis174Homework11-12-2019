using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    public class LogAsyncResourceFilter : Attribute, IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(
            ResourceExecutingContext context,
            ResourceExecutionDelegate next)
        { Console.WriteLine("Executing async!");
            ResourceExecutedContext executedContext = await next();
            Console.WriteLine("Executed async!");
         
        }
    }

}
