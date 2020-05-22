using System;
using System.Collections.Generic;
using System.Text;
using Tcs.Common.Domain.Commands;
using Tcs.Common.Domain.Exceptions;

namespace Tcs.Common.Models.Account.Commands
{
    public class CreateAccountCommand : Command
    {
        public string UserId { get; set; }

        public CreateAccountCommand(string userId)
        {
            UserId = userId;
        }
    }
}
