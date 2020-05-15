using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tcs.Account.Domain.Models;

namespace Tcs.Account.Domain.Repository
{
    public interface IAccountRepository
    {
        Task CreateAsync(UserAccount userAccount);
    }
}
