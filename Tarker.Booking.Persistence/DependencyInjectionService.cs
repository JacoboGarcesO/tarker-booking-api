using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.Database;
using Tarker.Booking.Persistence.Database;

namespace Tarker.Booking.Persistence
{
  public static class DependencyInjectionService
  {
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<DatabaseService>(options => options.UseSqlServer(configuration["SQLConnectionString"]));
      services.AddScoped<IDatabaseService, DatabaseService>();
      return services;
    }
  }
}
