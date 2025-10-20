using Microsoft.OpenApi.Models;

namespace PhoenixSubs.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Phoenix Subscription Management API", Version = "v1" });
        });

        return services;
    }
}
