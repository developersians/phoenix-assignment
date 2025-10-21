
using PhoenixSubs.Domain;

namespace PhoenixSubs.Application;

public sealed class SubscriptionPlanApplicationService(
    ISubscribedPlanRepository subscribedPlanRepository)
{
    public async Task<IEnumerable<SubscribedPlanDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await subscribedPlanRepository.GetAllAsync(cancellationToken);
    }

    public async Task<bool> ActivateAsync(
        Guid userId,
        Guid planId,
        CancellationToken cancellationToken = default)
    {
        return await subscribedPlanRepository.ActivateAsync(
            userId,
            planId,
            cancellationToken);
    }

    public async Task<bool> Deactivate(
        Guid userId,
        Guid subscriptionId,
        CancellationToken cancellationToken = default)
    {
        return await subscribedPlanRepository.DeactivateAsync(
            userId,
            subscriptionId,
            cancellationToken);
    }
}
