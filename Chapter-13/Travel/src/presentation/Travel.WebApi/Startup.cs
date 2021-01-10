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

            services.AddCors();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "../vue-app/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerExtension(provider);
            }

            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(b =>
            {
                b.AllowAnyOrigin();
                b.AllowAnyHeader();
                b.AllowAnyMethod();
            });

            app.UseHttpsRedirection();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            
            app.UseRouting();
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapToVueCliProxy(
                    pattern: "{*path}",
                    options: new SpaOptions {SourcePath = "../vue-app"},
                    npmScript:System.Diagnostics.Debugger.IsAttached ? "serve" : null,
                    regex: "Compiled successfully",
                    forceKill: true,
                    wsl: false // Set to true if you are using WSL on windows. For other operating systems it will be ignored
                );
            });
        }
    }
}