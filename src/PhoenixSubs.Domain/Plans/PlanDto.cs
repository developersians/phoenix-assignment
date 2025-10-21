namespace PhoenixSubs.Domain;

public sealed record PlanDto(
    Guid Id,
    string Title,
    PlanDuration Duration,
    PlanGroup Group,
    DateTime CreatedAt,
    DateTime LastUpdatedAt);
