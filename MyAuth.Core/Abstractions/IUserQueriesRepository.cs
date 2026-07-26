using MyAuth.Domain.Commands;
using MyAuth.Domain.Dto;

namespace MyAuth.Core.Abstractions
{
    //sperate reading from writing to the database, so we have two interfaces for user queries and user commands
    public interface IUserQueriesRepository
    {
        Task<UserDto?> FindUserAsync(LoginCommand login, CancellationToken ct);
        Task<bool> UserExistsAsync(string username, CancellationToken ct);
    }
    public interface IUserCommandsRepository
    {
        Task<bool> CreateUserAsync(RegisterCommand register, CancellationToken ct);
    }
}
