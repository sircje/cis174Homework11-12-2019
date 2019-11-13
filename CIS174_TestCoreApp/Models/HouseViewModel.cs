using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CIS174_TestCoreApp.Models
{
    public class HouseViewModel
    {
        public int bedrooms { get; set; }
        public int sqaureFeet { get; set; }
        public string dateBuilt { get; set; }
        public string flooring { get; set; }
    }
}
