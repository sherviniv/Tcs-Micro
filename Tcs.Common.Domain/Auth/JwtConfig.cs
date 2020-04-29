using System;
using System.Collections.Generic;
using System.Text;

namespace Tcs.Common.Domain.Auth
{
    public class JwtConfig
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}
