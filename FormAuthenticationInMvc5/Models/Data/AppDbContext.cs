using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormAuthenticationInMvc5.Models.Data
{
    public class AppDbContext :DbContext
    {

        public AppDbContext() :base("name=AppDbContext")
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
    }
}