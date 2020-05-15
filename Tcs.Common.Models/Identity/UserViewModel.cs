using System;
using System.Collections.Generic;
using System.Text;

namespace Tcs.Common.Models.Identity
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UserViewModel(string id,string firstName
                        ,string lastName,string email)
        {
            (this.Id, this.FirstName, this.LastName, this.Email) = (id, firstName, lastName, email);
        }
    }
}
