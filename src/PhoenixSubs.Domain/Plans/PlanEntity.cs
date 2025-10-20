using PhoenixSubs.Domain.Shared;

namespace PhoenixSubs.Domain;

public sealed class PlanEntity : Entity
{
    private PlanEntity() { }

    public string Title { get; private set; } = null!;
    public PlanDuration Duration { get; private set; }
    public PlanGroup Group { get; private set; }
    public ICollection<SubscribedPlanEntity> Subscriptions { get; private set; } = [];
}
