using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tcs.Common.Domain.Bus;
using Tcs.Common.Domain.Exceptions;
using Tcs.Common.Domain.Extensions;
using Tcs.Identity.Application.Interfaces;
using Tcs.Identity.Application.Models;

namespace Tcs.Identity.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly IEventBus _bus;

        public AccountController(
            IEventBus bus,
            IAccountService accountService,
            ILogger<AccountController> logger)
        {
            _bus = bus;
            _accountService = accountService;
            _logger = logger;
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterUserAsync([FromBody]CreateUser model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation(
                    "----- recieving request Createuser : {model} : Data ({data})",
                    model.GetGenericTypeName(),
                    model.GetObjectAsJson());

                var commandResult = await _accountService.RegisterAsync(model);

                if (!commandResult)
                {
                    return BadRequest();
                }

                return Ok();
            }
            else
            {
                throw new TcsException("invalid_data",
                      ModelState.Values.SelectMany(v => v.Errors));
            }

        }

    }
}
