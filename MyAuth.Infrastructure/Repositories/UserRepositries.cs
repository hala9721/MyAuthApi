using Microsoft.EntityFrameworkCore;
using MyAuth.Core.Abstractions;
using MyAuth.Domain;
using MyAuth.Domain.Commands;
using MyAuth.Domain.Dto;
using MyAuth.Infrastructure.Database;
using MyAuth.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAuth.Infrastructure.Repositories
{
    internal sealed class UserQueriesRepository(UserContext context) : IUserQueriesRepository
    {
      public async Task<UserDto?> FindUserAsync(LoginCommand login,CancellationToken ct)
        {
            var user =await context.Users.SingleOrDefaultAsync(u=>u.Username==login.Username,ct);
            if (user is null || !PasswordHasher.Verify(login.Password, user.Password))
                return null;

            return new UserDto(user.Id, user.Username, user.Role);
        }

        public async Task<bool> UserExistsAsync(string username, CancellationToken ct)
        {
            return await context.Users.AnyAsync(u => u.Username == username, ct);
        }
    }
    internal sealed class UserCommandsRepository(UserContext context) : IUserCommandsRepository
    {
        public async Task<bool> CreateUserAsync(RegisterCommand register, CancellationToken ct)
        {
            var user = new Entities.UserEntity
            {
                Username = register.Username,
                Password = PasswordHasher.Hash(register.Password),
                Role = AuthRoles.User,
                Email = register.Email
            };
            context.Users.Add(user);
            return await context.SaveChangesAsync(ct) > 0;
        }
    }

}
