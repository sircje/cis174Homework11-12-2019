using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class Assignment7_1Controller : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}