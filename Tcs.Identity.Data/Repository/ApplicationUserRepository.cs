using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tcs.Identity.Data.Context;
using Tcs.Identity.Domain.Models;
using Tcs.Identity.Domain.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tcs.Identity.Data.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly TcsIdentityDbContext _context;
        public ApplicationUserRepository(TcsIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Id == id.ToString());
        }

        public async Task<ApplicationUser> GetAsync(string usernameOremail)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Email == usernameOremail || c.UserName == usernameOremail);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
