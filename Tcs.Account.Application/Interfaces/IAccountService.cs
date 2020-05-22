using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tcs.Account.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Guid> CreateUserAccountAsync(string userId);
    }
}
