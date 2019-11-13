using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual string user { get; set; }
        public virtual string password { get; set; }
    }
}
