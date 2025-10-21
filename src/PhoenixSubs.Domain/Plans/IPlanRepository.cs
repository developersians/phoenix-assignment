namespace PhoenixSubs.Domain;

public interface IPlanRepository
{
    Task<IEnumerable<PlanDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
