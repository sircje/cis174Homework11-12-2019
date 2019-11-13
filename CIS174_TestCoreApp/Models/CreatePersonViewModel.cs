using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CIS174_TestCoreApp.Models
{
    public class CreatePersonViewModel
    {
        [Required]
        public string Country { get; set; }
        static public List<SelectListItem> Countries { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "Please select country" },
            new SelectListItem { Value = "MX", Text = "Mexico" },
            new SelectListItem { Value = "CA", Text = "Canada" },
            new SelectListItem { Value = "US", Text = "USA"  },
        };

        [Required]
        [StringLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(25)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [MinLength(2),StringLength(25)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Range(1, 120)]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress, StringLength(100)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Confirm Email")]
        [Compare(nameof(Email))]
        public string ConfirmEmail { get; set; }
        [Url]
        [MinLength(7)]
        public string Website { get; set; }
        [Editable(false)]
        public string School { get; set; }
        [Required]
        [Display(Name = "Password")]
        [Compare(nameof(ConfirmPassword))]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public System.DateTime DateOfBirth { get; set; }

    }
}
