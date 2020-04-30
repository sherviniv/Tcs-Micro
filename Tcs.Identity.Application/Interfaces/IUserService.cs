using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tcs.Identity.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync();
    }
}
