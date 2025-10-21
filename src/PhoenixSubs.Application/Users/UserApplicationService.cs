
using PhoenixSubs.Domain;

namespace PhoenixSubs.Application;

public sealed class UserApplicationService(
    IUserRepository userRepository)
{
    public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await userRepository.GetAllAsync(cancellationToken);
    }
}
