using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tcs.Account.Application.Interfaces;
using Tcs.Account.Domain.Models;
using Tcs.Account.Domain.Repository;
using Tcs.Common.Models.Account.Commands;

namespace Tcs.Account.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly ILogger _logger;
        private readonly IAccountRepository _accountRepository;

        public AccountService(
            IAccountRepository accountRepository,
            ILogger<AccountService> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }

        public async Task<Guid> CreateUserAccountAsync(string userId)
        {
           var userAccount = new UserAccount(userId);

           await _accountRepository.CreateAsync(userAccount);

           return userAccount.Id;
        }
    }
}
