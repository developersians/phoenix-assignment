using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoenixSubs.Infrastructure.Data;

namespace PhoenixSubs.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PhoenixDbContext>(options => options
                .UseSqlServer(connectionString: configuration.GetConnectionString("development"))
        );

        //services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
