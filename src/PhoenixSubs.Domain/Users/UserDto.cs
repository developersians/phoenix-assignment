namespace PhoenixSubs.Domain;

public sealed record UserDto(
    Guid Id,
    string Username,
    DateTime CreatedAt,
    DateTime LastUpdatedAt);
