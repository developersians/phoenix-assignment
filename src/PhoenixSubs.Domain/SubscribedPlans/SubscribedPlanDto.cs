namespace PhoenixSubs.Domain;

public sealed record SubscribedPlanDto(
    Guid Id,
    string Username,
    string PlanTitle,
    DateTime RegisteredDate,
    DateOnly StartDate,
    DateOnly EndDate,
    bool IsActive,
    DateTime CreatedAt,
    DateTime LastUpdatedAt
);
