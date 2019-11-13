using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CIS174_TestCoreApp.Models;



namespace CIS174_TestCoreApp.Controllers
{
    public class StudentController : Controller
    {
        [Route("Assignment6_1/{id:min(8):max(10)}")]
        public IActionResult Index(int id)
        {


            var studentList = new List<Student>{
                            new Student() { firstName = "Connor", lastName = "Eischen", grade = 90 } ,
                            new Student() { firstName = "Lucas", lastName = "Berg", grade = 85 } ,
                            new Student() { firstName = "Angie", lastName = "Tucker", grade = 95 } ,
                            new Student() { firstName = "John", lastName = "Harvey", grade = 70 }

                        };
            ViewData["Message"] = "Hello, Admin";
            return View(studentList);
        }
        [Route("Assignment6_1/{id}")]
        [Route("Assignment6_1")]
        public IActionResult Index2(int id)
        {
            return View();
        }
        [Route("Assignment6_1/{id:min(3):max(7)}")]
        public IActionResult Index3(int id)
        {
            var studentList = new List<Student>{
                            new Student() { firstName = "Connor", lastName = "Eischen", grade = 90 } ,
                            new Student() { firstName = "Lucas", lastName = "Berg", grade = 85 } ,
                            new Student() { firstName = "Angie", lastName = "Tucker", grade = 95 } ,
                            new Student() { firstName = "John", lastName = "Harvey", grade = 70 }

                        };
            return View(studentList);
        }

    }
}