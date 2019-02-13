using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BolForce.API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("StartupDataContext");
            //services.AddDbContext<StartupDataContext>(options => options.UseSqlServer(connection));

            return services;
        }
    }
}
