using MyAuth.Core.Abstractions;
using MyAuth.Core.Validation;
using MyAuth.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAuth.Core.UseCases
{
    internal sealed class RegisterCommandHandler(
        IUserQueriesRepository queries,
        IUserCommandsRepository commands,
        Ivalidator<RegisterCommand> validator) : IRequestHandler<bool ,RegisterCommand>
    {
        public async Task<DataResponse<bool>> HandleAsync(RegisterCommand request, CancellationToken ct)
        {
            var errors = validator.Validate(request);
            if (errors.Count > 0)
                return DataResponses.BadRequest<bool>([.. errors]);
            var existingUser = await queries.UserExistsAsync(request.Username, ct);
            if (await queries.UserExistsAsync(request.Username, ct))
               return DataResponses.BadRequest<bool>("Username already taken.");
            var created = await commands.CreateUserAsync(request, ct);
            return created ? DataResponses.Ok(true) : DataResponses.BadRequest<bool>("Failed to create user.");

        }
    }
}
