namespace PhoenixSubs.Domain;

public interface ISubscribedPlanRepository
{
    Task<IEnumerable<SubscribedPlanDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<bool> ActivateAsync(
        Guid userId,
        Guid planId,
        CancellationToken cancellationToken = default);

    Task<bool> DeactivateAsync(
        Guid userId,
        Guid subscriptionId,
        CancellationToken cancellationToken = default);
}
