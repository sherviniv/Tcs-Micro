using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tcs.Identity.Domain.Models;

namespace Tcs.Identity.Data.Context
{
    class TIdentityDbContext : IdentityDbContext<ApplicationUser, Role, string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public TIdentityDbContext(DbContextOptions<TIdentityDbContext> options) : base(options) 
        { 
        }

    }
}
