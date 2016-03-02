namespace Eshop.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Common.Roles;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<Eshop.Data.EshopDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EshopDbContext context)
        {
            IList<User> seededUsers = new List<User>();

            if (!context.Users.Any())
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));
                this.SeedAppRoles(context);
                seededUsers = this.SeedAppUsers(context, userManager);

                this.CreateCarts(context, seededUsers);
                this.CreateWishLists(context, seededUsers);
                this.CreatePurchaseHistory(context, seededUsers);
            }
        }
        private void CreateCarts(EshopDbContext context, IList<User> seededUsers)
        {
            foreach (var user in seededUsers)
            {
                user.Cart = new Cart();
            }
            context.SaveChanges();
        }

        private void CreateWishLists(EshopDbContext context, IList<User> seededUsers)
        {
            foreach (var user in seededUsers)
            {
                user.WishList = new WishList();
            }
            context.SaveChanges();
        }

        private void CreatePurchaseHistory(EshopDbContext context, IList<User> seededUsers)
        {
            foreach (var user in seededUsers)
            {
                user.PurchaseHistory = new PurchaseHistory();
            }
            context.SaveChanges();
        }

        private IList<User> SeedAppUsers(EshopDbContext context, UserManager<User> userManager)
        {
            var result = new List<User>();
            for (int i = 0; i < 5; i++)
            {
                var currentUser = new User
                {
                    UserName = "Testov" + i,
                    Email = string.Format("Test{0}@test.bg", i)
                };

                if (!userManager.Users.Any(x => x.UserName == currentUser.UserName))
                {
                    userManager.Create(currentUser, "Pass123");
                    userManager.AddToRole(currentUser.Id, AppRoles.CLIENT_ROLE);
                    result.Add(currentUser);
                }

            }

            var ultimateUsername = "ultimate";
            var ultimateUser = new User { UserName = ultimateUsername };

            if (!userManager.Users.Any(x => x.UserName == ultimateUsername))
            {
                userManager.Create(ultimateUser, "ultimate");
                userManager.AddToRole(ultimateUser.Id, AppRoles.ULTIMATE_ROLE);
                result.Add(ultimateUser);
            }

            return result;
        }

        private void SeedAppRoles(EshopDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            foreach (var roleName in AppRoles.AllRoles)
            {
                if (!roleManager.RoleExists(roleName))
                {
                    context.Roles.Add(new IdentityRole(roleName));
                }
            }
        }
    }
}
