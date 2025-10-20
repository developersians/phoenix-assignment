using PhoenixSubs.Domain.Shared;

namespace PhoenixSubs.Domain;

public sealed class UserEntity : Entity
{
    private UserEntity() { }

    public string UserName { get; private set; } = null!;
    public ICollection<SubscribedPlanEntity> Plans { get; private set; } = [];
}
