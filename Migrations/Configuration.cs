namespace Convocation.Migrations
{
    using Convocation.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Convocation.DAL;
    using Convocation.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<Convocation.DAL.ConvocationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override async void Seed(ConvocationDBContext convocationDBContext)
        {

            string[] roles = new string[] { "Administrator", "Student", "Teacher", "Stuff", "Officer" };

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(convocationDBContext));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(convocationDBContext));
            
            foreach (string role in roles)
            {
                //convocationDBContext.Roles.Any(r => r.Name == role);
                if (convocationDBContext.Roles.FirstOrDefault(r => r.Name == role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }


            var user = new ApplicationUser
            {
                Email = "arm.jamil@just.edu.bd",
                UserName = "Admin",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };


            if (!convocationDBContext.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher();
                var hashed = password.HashPassword("admin123!");
                user.PasswordHash = hashed;

                await UserManager.CreateAsync(user);
                await UserManager.AddToRoleAsync(user.Id, "Administrator");

                await convocationDBContext.SaveChangesAsync();

            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
