using MyAuth.Core.Abstractions;
using MyAuth.Core.Validation;
using MyAuth.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAuth.Core.UseCases
{
    internal sealed class LoginCommandHandler(IUserQueriesRepository users, ITokenService token, Ivalidator<LoginCommand> validator) : IRequestHandler <string , LoginCommand>
    {
        public async Task<DataResponse<string>> HandleAsync(LoginCommand request, CancellationToken ct)
        {
           var errors = validator.Validate(request);
            if (errors.Count > 0)
                return DataResponses.BadRequest<string>([.. errors]);
            var user = await users.FindUserAsync(request, ct);
            if(user is null)
                return DataResponses.Unauthorized<string>("Invalid username or password");

            return DataResponses.Ok(token.GenerateToken(user));

        }
    }
}
