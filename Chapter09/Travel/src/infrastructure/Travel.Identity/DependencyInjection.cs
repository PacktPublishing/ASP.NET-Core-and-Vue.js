using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travel.Application.Common.Interfaces;
using Travel.Identity.Helpers;
using Travel.Identity.Services;

namespace Travel.Identity
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructureIdentity(this IServiceCollection services, IConfiguration config)
    {
      services.Configure<AuthSettings>(config.GetSection(nameof(AuthSettings)));
      services.AddScoped<IUserService, UserService>();
      
      return services;
    }
  }
}