using Microsoft.EntityFrameworkCore;
using PhoenixSubs.Domain;

namespace PhoenixSubs.Infrastructure.Data
{
    internal sealed class SubscribedPlanRepository(PhoenixDbContext db) : ISubscribedPlanRepository
    {
        public async Task<IEnumerable<SubscribedPlanDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var results = await db.SubscribedPlans.Select(x => new
            {
                x.Id,
                x.User.UserName,
                x.Plan.Title,
                x.RegisteredDate,
                x.StartDate,
                x.EndDate,
                x.IsActive
            })
            .ToListAsync();

            return results.Select(x => new SubscribedPlanDto(
                x.Id,
                x.UserName,
                x.Title,
                x.RegisteredDate,
                x.StartDate,
                x.EndDate,
                x.IsActive));
        }
    }
}
