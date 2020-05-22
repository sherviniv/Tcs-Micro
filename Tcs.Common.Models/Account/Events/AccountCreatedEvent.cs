using System;
using System.Collections.Generic;
using System.Text;
using Tcs.Common.Domain.Events;

namespace Tcs.Common.Models.Account.Events
{
    public class AccountCreatedEvent : Event
    {
        public string UserId { get; set; }
        public string AccountId { get; set; }

        public AccountCreatedEvent(string userId,string accountId)
        {
            (this.UserId, this.AccountId) = (userId, accountId);
        }
    }
}
