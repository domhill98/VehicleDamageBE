﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VehicleDamage_BackEnd_Data;

namespace VehicleDamage_BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var env = services.GetRequiredService<IHostingEnvironment>();
                if (env.IsDevelopment())
                {
                    var context = services.GetRequiredService<VehicleDamageDB>();
                
                    try
                    {
                        context.Database.Migrate();

                        VehicleDamageDBInitialiser.SeedTestData(context, services).Wait();
                    }
                    catch (Exception)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogDebug("Seeding test data failed.");
                    }
                }
            }




            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
