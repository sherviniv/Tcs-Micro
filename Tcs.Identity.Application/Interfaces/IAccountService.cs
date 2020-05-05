using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tcs.Identity.Application.Models;

namespace Tcs.Identity.Application.Interfaces
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(CreateUser model);

    }
}
