using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tcs.Common.Domain.Bus;
using Tcs.Common.Models.Account.Events;
using Tcs.Identity.Application.Interfaces;

namespace Tcs.Identity.Application.EventHandlers
{
    public class AccountCreatedEventHandler : IEventHandler<AccountCreatedEvent>
    {
        private IUserService _userService { get; }

        public AccountCreatedEventHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(AccountCreatedEvent @event)
        {
            await _userService.UpdateUserAccountAsync(@event.UserId, @event.AccountId);
        }
    }
}
