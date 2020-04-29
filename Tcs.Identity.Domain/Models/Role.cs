using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tcs.Identity.Domain.Models
{
    public class Role : IdentityRole<string>
    {
        public Role()
        {
        }

        public Role(string RoleName):base(RoleName)
        {

        }
    }
}
