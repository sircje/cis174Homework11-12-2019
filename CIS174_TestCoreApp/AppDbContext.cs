using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CIS174_TestCoreApp.Models;
using CIS174_TestCoreApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CIS174_TestCoreApp
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {


        public AppDbContext(DbContextOptions<AppDbContext> options)
: base(options) { }
        public DbSet<FamousPeople> FamousPeoples { get; set; }
        public DbSet<CIS174_TestCoreApp.Models.Achievements> Achievements { get; set; }
        public DbSet<ErrorLogTable> ErrorLog { get; set; }
        public DbSet<CIS174_TestCoreApp.Models.FamousPeopleViewModel> FamousPeopleViewModel { get; set; }

    }
   
}
