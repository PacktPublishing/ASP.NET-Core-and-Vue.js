using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Compact;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Travel.Data.Contexts;

namespace Travel.WebApi
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var name = Assembly.GetExecutingAssembly().GetName();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithMachineName()
                .Enrich.WithProperty("Assembly", $"{name.Name}")
                .Enrich.WithProperty("Assembly", $"{name.Version}")
                .WriteTo.SQLite(
                    Environment.CurrentDirectory + @"/Logs/log.db",
                    restrictedToMinimumLevel: LogEventLevel.Information,
                    storeTimestampInUtc: true)
                .WriteTo.File(
                    new CompactJsonFormatter(),
                    Environment.CurrentDirectory + @"/Logs/log.json",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information)
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting host");
                var host = CreateHostBuilder(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var context = services.GetRequiredService<ApplicationDbContext>();
                        
                        if (context.Database.IsSqlServer())
                            await context.Database.MigrateAsync();

                        await ApplicationDbContextSeed.SeedSampleDataAsync(context);
                    }

                    catch (Exception ex)
                    {
                        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while migrating or seeding the database");

                        throw;
                    }
                }

                await host.RunAsync();

                return 0;
            }

            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }

            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}