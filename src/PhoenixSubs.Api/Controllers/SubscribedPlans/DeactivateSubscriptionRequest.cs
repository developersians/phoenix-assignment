namespace PhoenixSubs.Api;

public sealed record DeactivateSubscriptionRequest(
    Guid UserId,
    Guid SubscriptionId);
