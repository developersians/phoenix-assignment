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
                x.IsActive,
                x.CreatedAt,
                x.LastUpdatedAt
            })
            .ToListAsync();

            return results.Select(x => new SubscribedPlanDto(
                x.Id,
                x.UserName,
                x.Title,
                x.RegisteredDate,
                x.StartDate,
                x.EndDate,
                x.IsActive,
                x.CreatedAt,
                x.LastUpdatedAt));
        }

        public async Task<bool> ActivateAsync(Guid userId, Guid planId, CancellationToken cancellationToken = default)
        {
            PlanEntity? plan = await db.Plans
                .FirstOrDefaultAsync(x => x.Id == planId, cancellationToken);

            if (plan is null)
                return false;

            SubscribedPlanEntity subscription = SubscribedPlanEntity.Create(
                userId: userId,
                planId: planId,
                duration: plan.Duration,
                registeredDate: DateTime.UtcNow
            );
            subscription.MarkAsActive();

            await db.SubscribedPlans.AddAsync(subscription, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeactivateAsync(
            Guid userId,
            Guid subscriptionId,
            CancellationToken cancellationToken = default)
        {
            SubscribedPlanEntity? subscription = await db.SubscribedPlans
                .FirstOrDefaultAsync(x => x.Id == subscriptionId, cancellationToken);

            if (subscription is null)
                return false;

            if (subscription.UserId != userId)
                return false;

            subscription.MarkAsInActive();

            db.SubscribedPlans.Update(subscription);
            await db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
