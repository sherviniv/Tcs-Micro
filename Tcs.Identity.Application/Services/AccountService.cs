using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcs.Identity.Application.Handler;
using Tcs.Identity.Application.Interfaces;
using Tcs.Identity.Application.Models;
using Tcs.Identity.Domain.Models;

namespace Tcs.Identity.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly ILogger _logger;
        private readonly IJwtHandler _jwtHandler;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IJwtHandler jwtHandler,
             ILogger<AccountService> logger)
        {
            _logger = logger;
            _jwtHandler = jwtHandler;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> RegisterAsync(CreateUser model)
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Errors.Count() > 0)
            {
                return false;
            }

            return true;
        }

        public async Task<string> LoginAsync(AuthenticateUser model)
        {
                throw new NotImplementedException();
        }
    }
}
