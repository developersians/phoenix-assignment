namespace PhoenixSubs.Domain;

public interface IUserRepository
{
    Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
