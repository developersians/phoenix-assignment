using Microsoft.EntityFrameworkCore;
using PhoenixSubs.Domain;

namespace PhoenixSubs.Infrastructure.Data
{
    internal sealed class UserRepository(PhoenixDbContext db) : IUserRepository
    {
        public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var results = await db.Users.Select(x => new
            {
                x.Id,
                x.UserName,
                x.CreatedAt,
                x.LastUpdatedAt
            })
            .ToListAsync();

            return results.Select(x => new UserDto(
                x.Id,
                x.UserName,
                x.CreatedAt,
                x.LastUpdatedAt));
        }
    }
}
