
using PhoenixSubs.Domain;

namespace PhoenixSubs.Application;

public sealed class SubscriptionPlanApplicationService(
    ISubscribedPlanRepository subscribedPlanRepository)
{
    public async Task<IEnumerable<SubscribedPlanDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await subscribedPlanRepository.GetAllAsync(cancellationToken);
    }
}
