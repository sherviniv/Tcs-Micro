using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tcs.Account.Application.Interfaces;
using Tcs.Common.Domain.Bus;
using Tcs.Common.Domain.Extensions;
using Tcs.Common.Models.Account.Commands;
using Tcs.Common.Models.Account.Events;
using Tcs.Common.Models.Identity.Events;

namespace Tcs.Account.Application.EventHandlers
{
    public class UserCreatedEventHandler : IEventHandler<UserCreatedEvent>
    {
        private readonly IEventBus _bus;
        private IAccountService _accountService { get; }

        public UserCreatedEventHandler(
            IAccountService accountService,
            IEventBus bus)
        {
            _accountService = accountService;
            _bus = bus;
        }

        public async Task Handle(UserCreatedEvent @event)
        {

            var accountId = await _accountService.CreateUserAccountAsync(@event.UserId);
            _bus.Publish(new AccountCreatedEvent(@event.UserId, accountId.ToString()));

        }
    }
}
