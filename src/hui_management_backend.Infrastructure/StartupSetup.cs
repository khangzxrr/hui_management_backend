using Hangfire;
using hui_management_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace hui_management_backend.Infrastructure;

public static class StartupSetup
{
  public static void AddDbContext(this IServiceCollection services, string connectionString) =>
      services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(connectionString)); // will be created in web project root

  public static void AddHangfireService(this IServiceCollection services, string connectionString)
  {
    services.AddHangfire(config =>
    {
      config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180);
      config.UseSimpleAssemblyNameTypeSerializer();
      config.UseRecommendedSerializerSettings();
      config.UseSqlServerStorage(connectionString!);
    });

    services.AddHangfireServer();
  }
}
