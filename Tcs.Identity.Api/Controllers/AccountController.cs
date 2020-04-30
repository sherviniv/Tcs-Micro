using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tcs.Common.Domain.Bus;
using Tcs.Common.Domain.Extensions;
using Tcs.Identity.Domain.Commands;

namespace Tcs.Identity.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IEventBus _bus;

        public AccountController(
            IEventBus bus,
            ILogger<AccountController> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterUserAsync([FromBody]CreateUser command)
        {
            _logger.LogInformation(
                                "----- Sending command: {CommandName} : Data ({})",
                                command.GetGenericTypeName(),
                                command);
                            
            var commandResult = await _bus.SendCommand(command);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
