namespace SwitchYourHome.Migrations
{
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SwitchYourHome.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SwitchYourHome.Data.AppDbContext context)
        {
            if (!context.Roles.Any())
            {
                this.CreateRole(context, "Admin");
                this.CreateRole(context, "User");
            }

            if (!context.Users.Any())
            {
                this.CreateUser("admin@admin.com", "Admin", "123", context);
                this.SetUserRole("admin@admin.com", "Admin", context);

                this.CreateUser("a@abv.com", "Adam", "111", context);
                this.SetUserRole("a@abv.com", "User", context);
            }
        }
        private void SetUserRole(string email, string role, SwitchYourHome.Data.AppDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var userId = context.Users.FirstOrDefault(u => u.Email.Equals(email)).Id;
            var result = userManager.AddToRole(userId, role);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateUser(string email, string fullName, string pass, SwitchYourHome.Data.AppDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            userManager.PasswordValidator = new PasswordValidator
            {
                RequireDigit = false,
                RequiredLength = 1,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
            };

            var user = new ApplicationUser()
            {
                Email = email,
                FullName = fullName,
                UserName = email,
            };

            var result = userManager.Create(user, pass);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateRole( SwitchYourHome.Data.AppDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            var result = roleManager.Create(new IdentityRole(roleName));

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }
    }
}
