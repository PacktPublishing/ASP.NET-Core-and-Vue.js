using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Travel.Application;
using Travel.Data;
using Travel.Identity;
using Travel.Identity.Helpers;
using Travel.Shared;
using Travel.WebApi.Extensions;
using Travel.WebApi.Helpers;
using VueCliMiddleware;

namespace Travel.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication(Configuration);
            services.AddInfrastructureData(Configuration);
            services.AddInfrastructureShared(Configuration);
            services.AddInfrastructureIdentity(Configuration);

            services.AddHttpContextAccessor();
            services.AddControllers();

            services.AddApiVersioningExtension();
            services.AddVersionedApiExplorerExtension();
            services.AddSwaggerGenExtension();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            // NOTE: PRODUCTION Ensure this is the same path that is specified in your webpack output
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "../vue-app/dist";
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerExtension(provider);
            }

            // PRODUCTION uses webpack static files
            app.UseSpaStaticFiles();

            app.UseCors(b =>
            {
                b.AllowAnyOrigin();
                b.AllowAnyHeader();
                b.AllowAnyMethod();
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // NOTE: VueCliProxy is meant for developement and hot module reload
                // NOTE: SSR has not been tested
                // Production systems should only need the UseSpaStaticFiles() (above)
                // You could wrap this proxy in either
                // if (System.Diagnostics.Debugger.IsAttached)
                // or a preprocessor such as #if DEBUG
                
                endpoints.MapToVueCliProxy(
                    pattern: "{*path}",
                    options: new SpaOptions { SourcePath = "../vue-app" },
                    npmScript: System.Diagnostics.Debugger.IsAttached ? "serve" : null,
                    regex: "Compiled successfully",
                    forceKill: true,
                    wsl: false // Set to true if you are using WSL on windows. For other operating systems it will be ignored
                );
            });
            
            // Adding this UseSpa removes the required time before launching Vue as SPA
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../vue-app";
                
                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }
            });
        }
    }
}