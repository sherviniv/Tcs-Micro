﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcs.Common.Domain.Exceptions;
using Tcs.Common.Models.Identity;
using Tcs.Identity.Application.Handler;
using Tcs.Identity.Application.Interfaces;
using Tcs.Identity.Domain.Models;
using Tcs.Identity.Domain.Repository;

namespace Tcs.Identity.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger _logger;
        private readonly IJwtHandler _jwtHandler;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IJwtHandler jwtHandler,
            IApplicationUserRepository applicationUserRepository,
             ILogger<UserService> logger)
        {
            _logger = logger;
            _jwtHandler = jwtHandler;
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationUserRepository = applicationUserRepository;
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
            var user = await _applicationUserRepository.GetAsync(model.UserName);

            if (user == null)
                throw new TcsException("invalid_credentials",
                        "User cannot be find.");

            var result = await _signInManager.CheckPasswordSignInAsync(user
                  , model.Password, true);

            if (!result.Succeeded)
                throw new TcsException("invalid_credentials",
                    "invalid_credentials.");

            return _jwtHandler.Generate(user);
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var usersList = await _applicationUserRepository.GetAsync();

            return usersList.Select(c => MapToUserViewModel(c));
        }

        public async Task<bool> UpdateUserAccountAsync(string userId, string newAccountId)
        {
            var user = await _applicationUserRepository.GetAsync(Guid.Parse(userId));

            if (user == null)
                throw new TcsException("invalid_userid",
                        "User cannot be find.");

            user.AccountId = newAccountId;
            var result = await _userManager.UpdateAsync(user);

            if (result.Errors.Count() > 0)
            {
                return false;
            }

            return true;
        }

        public async Task<UserViewModel> GetUserAsync(string email)
        {
            var user = await _applicationUserRepository.GetAsync(email);

            if (user == null)
                throw new TcsException("invalid_email",
                            "User cannot be find.");

            return MapToUserViewModel(user);
        }

        private UserViewModel MapToUserViewModel(ApplicationUser user)
        {
            return new UserViewModel(user.Id, user.FirstName, user.LastName, user.Email);
        }
    }
}
