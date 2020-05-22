using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tcs.Account.Application.Interfaces;
using Tcs.Common.Domain.Bus;
using Tcs.Common.Models.Account.Events;

namespace Tcs.Common.Models.Account.Commands
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, bool>
    {
        private readonly IEventBus _bus;
        private IAccountService _accountService { get; }

        public CreateAccountCommandHandler(
            IAccountService accountService
            , IEventBus bus)
        {
            _accountService = accountService;
            _bus = bus;
        }

        public async Task<bool> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var accountId = await _accountService.CreateUserAccountAsync(request.UserId);

            _bus.Publish(new AccountCreatedEvent(request.UserId, accountId.ToString()));

            return true;
        }
    }
}
