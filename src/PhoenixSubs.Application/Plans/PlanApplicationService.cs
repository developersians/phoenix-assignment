
using PhoenixSubs.Domain;

namespace PhoenixSubs.Application;

public sealed class PlanApplicationService(
    IPlanRepository planRepository)
{
    public async Task<IEnumerable<PlanDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await planRepository.GetAllAsync(cancellationToken);
    }
}
