using System;
using System.Collections.Generic;
using System.Text;
using Tcs.Common.Domain.Events;

namespace Tcs.Common.Models.Identity.Events
{
    public class UserCreatedEvent : Event
    {
        public string UserId { get; set; }

        public UserCreatedEvent(string userid)
        {
            UserId = userid;
        }
    }
}
