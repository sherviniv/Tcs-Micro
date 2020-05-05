using System;
using System.Collections.Generic;
using System.Text;

namespace Tcs.Identity.Application.Models
{
    public class AuthenticateUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
