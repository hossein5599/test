using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAuthenticationInMvc5.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserMail { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}