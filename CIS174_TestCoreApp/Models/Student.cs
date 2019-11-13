using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CIS174_TestCoreApp.Models
{
    public class Student
    {
        [Display(Name = "First Name")]
        public string firstName {get; set;}
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Grade %")]
        public int grade { get; set; }
    }
}
