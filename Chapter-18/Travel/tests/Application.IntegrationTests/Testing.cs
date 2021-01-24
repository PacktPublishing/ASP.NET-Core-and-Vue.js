using System;
using System.IO;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Respawn;
using Travel.Data.Contexts;
using Travel.WebApi;
using Xunit;

namespace Application.IntegrationTests
{
    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<Testing>
    {
    }

    public class Testing : IDisposable
    {
        private static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;
        private static Checkpoint _checkpoint;

        public Testing()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();

            
            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "Travel.WebApi"));
            
            services.AddLogging();
            
            startup.ConfigureServices(services);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[] { "__EFMigrationsHistory" }
            };

            EnsureDatabase();
        }

        private static void EnsureDatabase()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetService<IMediator>();
            return await mediator.Send(request);
        }

        public static async Task ResetState()
        {
            await _checkpoint.Reset(_configuration.GetConnectionString("DefaultConnection"));
        }

        public static async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Add(entity);
            await context.SaveChangesAsync();
        }
        
        public static async Task<TEntity> FindAsync<TEntity>(int id)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return await context.FindAsync<TEntity>(id);
        }

        void IDisposable.Dispose()
        {
            // Code to run after all tests
        }
    }
}