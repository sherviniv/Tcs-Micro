using System;
using System.Collections.Generic;
using System.Text;
using Tcs.Common.Domain.Exceptions;

namespace Tcs.Account.Domain.Models
{
    public class UserAccount
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
        public decimal Balance { get; set; }

        protected UserAccount()
        {
        }

        public UserAccount(string userId)
        {

            if (string.IsNullOrEmpty(userId))
                throw new TcsException("empty_userid",
                     "userid can not be empty.");

            Id = Guid.NewGuid();
            UserId = userId;
            CreateDate = DateTime.Now;
            Balance = 0;
        }

    }
}
