using System;
using System.Collections.Generic;
using System.Text;
using Tcs.Common.Domain.Commands;

namespace Tcs.Identity.Domain.Commands
{
    public class CreateUser : Command
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
