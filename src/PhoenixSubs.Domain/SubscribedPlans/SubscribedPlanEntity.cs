using PhoenixSubs.Domain.Shared;

namespace PhoenixSubs.Domain;

public sealed class SubscribedPlanEntity : Entity
{
    private SubscribedPlanEntity() { }

    public Guid UserId { get; private set; }
    public Guid PlanId { get; private set; }
    public DateTime RegisteredDate { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public bool IsActive { get; private set; }
    public UserEntity User { get; private set; }
    public PlanEntity Plan { get; private set; }

    public static SubscribedPlanEntity Create(
        Guid userId,
        Guid planId,
        PlanDuration duration,
        DateTime registeredDate)
    {
        var subscription = new SubscribedPlanEntity
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            PlanId = planId,
            RegisteredDate = registeredDate,
            StartDate = DateOnly.FromDateTime(registeredDate)
        };
        subscription.CalculateDurability(duration);
        subscription.MarkAsActive();

        return subscription;
    }

    public void MarkAsActive()
    {
        IsActive = true;
    }

    public void MarkAsInActive()
    {
        IsActive = false;
    }

    private void CalculateDurability(PlanDuration duration)
    {
        EndDate = DateOnly.FromDateTime(RegisteredDate.AddMonths((int)duration));
    }
}
