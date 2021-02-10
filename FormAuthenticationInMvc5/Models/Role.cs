using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FormAuthenticationInMvc5.Models
{
    
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string RoleName { get; set; }

        public string RoleInSystem { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}