using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tcs.Identity.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() 
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountId { get; set; }
    }
}
