using Microsoft.EntityFrameworkCore;
using PhoenixSubs.Domain;
using PhoenixSubs.Infrastructure.Data;

namespace PhoenixSubs.Api;

internal sealed class DataSeederHostedService(
    IServiceScopeFactory serviceScopeFactory,
    ILogger<DataSeederHostedService> logger) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<PhoenixDbContext>();

        await context.Database.EnsureCreatedAsync(cancellationToken);

        await SeedUsersAsync(context, cancellationToken);
        await SeedPlansAsync(context, cancellationToken);
        logger.LogInformation("Seeding successed");
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    private async Task SeedUsersAsync(PhoenixDbContext context, CancellationToken cancellationToken)
    {
        if (await context.Users.AnyAsync(cancellationToken))
            return;

        var users = new List<UserEntity>
        {
            UserEntity.Create("Aref"),
            UserEntity.Create("Reza"),
            UserEntity.Create("Nozar"),
            UserEntity.Create("Akbari")

        };

        await context.Users.AddRangeAsync(users, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    private async Task SeedPlansAsync(PhoenixDbContext context, CancellationToken cancellationToken)
    {
        if (await context.Plans.AnyAsync(cancellationToken))
            return;

        var plans = new List<PlanEntity>
        {
            PlanEntity.Create("6 month length bronze plan", PlanDuration.SixMonth, PlanGroup.Bronze),
            PlanEntity.Create("6 month length silver plan", PlanDuration.SixMonth, PlanGroup.Silver),
            PlanEntity.Create("Amazing 6 month length gold plan", PlanDuration.SixMonth, PlanGroup.Gold),
            PlanEntity.Create("1 year length gold plan", PlanDuration.TwelveMonth, PlanGroup.Gold),
            PlanEntity.Create("Fantastic 1 year length platinum plan", PlanDuration.TwelveMonth, PlanGroup.Platinum),
        };

        await context.Plans.AddRangeAsync(plans, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
