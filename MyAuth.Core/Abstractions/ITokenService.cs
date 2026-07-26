using MyAuth.Domain.Dto;

namespace MyAuth.Core.Abstractions
{
    public interface ITokenService
    {
        string GenerateToken(UserDto user);
    }
}
