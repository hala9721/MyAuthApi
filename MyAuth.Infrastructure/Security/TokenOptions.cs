using System;
using System.Collections.Generic;
using System.Text;

namespace MyAuth.Infrastructure.Security
{
    public sealed class TokenOptions
    {
        public required string Issuer { get; set; }
        public required string Key { get; set; }
        public required int ExpirationInMinutes{ get; set; } = 60;
        public required string Audience { get; set; }
    }
}
