using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class AdminController : Controller
    {

        [Route("Assignment12_2")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}