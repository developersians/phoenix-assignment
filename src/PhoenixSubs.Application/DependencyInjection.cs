using Microsoft.Extensions.DependencyInjection;

namespace PhoenixSubs.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<UserApplicationService>();
        services.AddScoped<PlanApplicationService>();
        services.AddScoped<SubscriptionPlanApplicationService>();
        return services;
    }
}
