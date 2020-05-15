using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tcs.Common.Models.Identity;

namespace Tcs.Identity.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(CreateUser model);
        Task<string> LoginAsync(AuthenticateUser model);
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
    }
}
