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
using Tcs.Common.Models.Identity.Events;
using Tcs.Identity.Application.Interfaces;

namespace Tcs.Identity.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _accountService;
        private readonly IEventBus _bus;

        public UserController(
            IEventBus bus,
            IUserService accountService,
            ILogger<UserController> logger)
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

                _bus.Publish(new UserCreatedEvent(user.Id));

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
