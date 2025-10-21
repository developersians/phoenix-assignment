using Microsoft.EntityFrameworkCore;
using PhoenixSubs.Domain;

namespace PhoenixSubs.Infrastructure.Data
{
    internal sealed class PlanRepository(PhoenixDbContext db) : IPlanRepository
    {
        public async Task<IEnumerable<PlanDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var results = await db.Plans.Select(x => new
            {
                x.Id,
                x.Title,
                x.Duration,
                x.Group,
                x.CreatedAt,
                x.LastUpdatedAt
            })
            .ToListAsync();

            return results.Select(x => new PlanDto(
                x.Id,
                x.Title,
                x.Duration,
                x.Group,
                x.CreatedAt,
                x.LastUpdatedAt));
        }
    }
}
