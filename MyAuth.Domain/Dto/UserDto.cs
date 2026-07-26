using System;
using System.Collections.Generic;
using System.Text;

namespace MyAuth.Domain.Dto
{
    public sealed record UserDto(int Id, string Username,  string Role);
}
