namespace PhoenixSubs.Domain;

public interface ISubscribedPlanRepository
{
    Task<IEnumerable<SubscribedPlanDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
