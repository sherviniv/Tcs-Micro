using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tcs.Identity.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        protected ApplicationUser() 
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
