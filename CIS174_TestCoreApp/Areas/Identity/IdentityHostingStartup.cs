using System;
using CIS174_TestCoreApp.Entities;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CIS174_TestCoreApp.Areas.Identity.IdentityHostingStartup))]
namespace CIS174_TestCoreApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CIS174_TestCoreAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CIS174_TestCoreAppContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>()
                    .AddEntityFrameworkStores<CIS174_TestCoreAppContext>();
            });
        }
    }
}