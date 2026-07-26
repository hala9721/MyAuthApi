using System;
using System.Collections.Generic;
using System.Text;

namespace MyAuth.Domain.Commands
{
    public sealed record LoginCommand(string Username, string Password);
    
}
