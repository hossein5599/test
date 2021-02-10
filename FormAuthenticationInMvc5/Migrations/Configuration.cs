namespace FormAuthenticationInMvc5.Migrations
{
    using FormAuthenticationInMvc5.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FormAuthenticationInMvc5.Models.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FormAuthenticationInMvc5.Models.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Roles.AddOrUpdate(r => r.Id,
                new Role() { Id = 1, RoleInSystem = "Admin", RoleName = "ادمین" },
                new Role() {Id=2 , RoleInSystem="User", RoleName="کاربر" }

                );
            context.Users.AddOrUpdate(r => r.Id,
                new User() { Id = 1, UserMail = "admin@gmail.com", FirstName = "hossein", LastName = "sadeghi", RoleId = 1, PhoneNumber = "09010192167", Password = "123" },
                new User() { Id = 2, UserMail = "user1@gmail.com", FirstName = "user1name", LastName = "user1familyname", RoleId = 2, PhoneNumber = "09925548014", Password = "321" }

                );
            context.SaveChanges();

        }
    }
}
