using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PcnUniApp.Infrastructure.Identity;

[assembly: HostingStartup(typeof(PcnUniApp.Web.Areas.Identity.IdentityHostingStartup))]
namespace PcnUniApp.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                builder.ConfigureServices((context, services) => {
                    services.AddDbContext<CollegeIdentityDbContext>(options =>
                        options.UseSqlServer(
                            context.Configuration.GetConnectionString("CollegeIdentityConnection")));

                    services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                        .AddEntityFrameworkStores<CollegeIdentityDbContext>();
                });
            });
        }
    }
}