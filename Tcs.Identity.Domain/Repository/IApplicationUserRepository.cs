using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tcs.Identity.Domain.Models;

namespace Tcs.Identity.Domain.Repository
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> GetAsync(Guid id);
        Task<ApplicationUser> GetAsync(string usernameOremail);
        Task<IEnumerable<ApplicationUser>> GetAsync();
    }
}
