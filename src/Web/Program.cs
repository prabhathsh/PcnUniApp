using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PcnUniApp.Infrastructure.Data;

namespace Web
{
    public class Program
    {
        public static async Task  Main(string[] args)
        {
            var host = CreateWebHostBuilder(args)
                       .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var collegeContext = services.GetRequiredService<CollegeContext>();
                    await CollegeContextSeed.SeedAsync(collegeContext, loggerFactory);

                   
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                 .UseStartup<Startup>();
    }
}
