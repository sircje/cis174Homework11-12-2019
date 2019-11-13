using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    public class LogResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(
            ResourceExecutingContext context)
        {
            Guid.NewGuid();
            Console.WriteLine("Executing");
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Guid.NewGuid();
            Console.WriteLine("Executed");
        }

    }
}
