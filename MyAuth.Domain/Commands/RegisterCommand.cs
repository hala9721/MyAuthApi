using System;
using System.Collections.Generic;
using System.Text;

namespace MyAuth.Domain.Commands
{
   public sealed record RegisterCommand(string Username, string Password, string Email);
}
