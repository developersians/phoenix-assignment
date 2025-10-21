namespace PhoenixSubs.Api;

public sealed record ActivateSubscriptionRequest(
    Guid UserId,
    Guid PlanId);
