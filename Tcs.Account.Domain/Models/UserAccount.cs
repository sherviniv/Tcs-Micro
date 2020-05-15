using System;
using System.Collections.Generic;
using System.Text;

namespace Tcs.Account.Domain.Models
{
    public class UserAccount
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
        public decimal Balance { get; set; }
    }
}
