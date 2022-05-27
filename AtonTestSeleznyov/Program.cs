using Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtonTestSeleznyov
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            IHost host = default;
            ILogger<Program> logger = default;
            try
            {
                host = CreateHostBuilder(args).Build();
                logger = CreateLogger(host.Services);
                await ApplyMigrationsAsync(host.Services);
                logger.LogInformation("Migrate successfuly");
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static ILogger<Program> CreateLogger(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            return scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        }
        public async static Task ApplyMigrationsAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            using var dB = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await dB.Database.MigrateAsync();
        }
    }
}
