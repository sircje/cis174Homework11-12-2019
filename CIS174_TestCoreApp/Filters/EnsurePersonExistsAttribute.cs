using CIS174_TestCoreApp.Models;
using CIS174_TestCoreApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    public class EnsureResipeExistsFilter : IActionFilter
    {
        private readonly FamousPeopleService _service;
        public EnsureResipeExistsFilter (FamousPeopleService service)
        {
            _service = service;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //nothing to do here
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var id = (int)context.ActionArguments["id"];

            if (!_service.DoesPersonExist(id))
            {
                context.Result = new NotFoundResult();
            }
        }
    }



    public class EnsurePersonExistsAttribute : TypeFilterAttribute
    {
        public EnsurePersonExistsAttribute()
            : base(typeof(EnsureResipeExistsFilter))
        {

        }
    }
}
