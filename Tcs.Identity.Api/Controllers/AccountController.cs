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
using Tcs.Common.Models.Account.Commands;
using Tcs.Common.Models.Identity;
using Tcs.Identity.Application.Interfaces;

namespace Tcs.Identity.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _accountService;
        private readonly IEventBus _bus;

        public AccountController(
            IEventBus bus,
            IUserService accountService,
            ILogger<AccountController> logger)
        {
            _bus = bus;
            _accountService = accountService;
            _logger = logger;
        }

        [HttpPut]
        [Route("Register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterUser([FromBody]CreateUser model)
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

                var user = await _accountService.GetUserAsync(model.Email);

                var command = new CreateAccountCommand(user.Id);

                _logger.LogInformation(
                  "----- Sending command: {CommandName} : ({@Command})",
                    model.GetGenericTypeName(),
                    model.GetObjectAsJson());

                await _bus.SendCommand(command);

                return Ok();
            }
            else
            {
                throw new TcsException("invalid_data",
                      ModelState.Values.SelectMany(v => v.Errors));
            }

        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Login([FromBody]AuthenticateUser model)
        {
                _logger.LogInformation(
                    "----- recieving request Login  : {model} : Data ({data})",
                    model.GetGenericTypeName(),
                    model.GetObjectAsJson());

                var jwttoken = await _accountService.LoginAsync(model);

                return Ok(jwttoken);
        }

        [HttpPost]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            _logger.LogInformation(
                "----- recieving request GetUsers  : {model} : Data ({data})");

            var users = await _accountService.GetUsersAsync();

            return Ok(users);
        }

    }
}
