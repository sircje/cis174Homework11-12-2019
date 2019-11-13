using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace CIS174_TestCoreApp.Models
{
    public class Achievements
    {
        [Key]
        [Display(Name = "ID")]
        public int AchievementsId { get; set; }
        [Required]
        [Range(1,99)]
        [Display(Name = "Person ID")]
        public int FamousPeopleId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Date of Accomplishmnet")]
        public string doa { get; set; }
    }
}