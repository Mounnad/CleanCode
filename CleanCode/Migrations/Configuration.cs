namespace CleanCode.Migrations
{
    using Entities;
    using Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CleanCode.EnumsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CleanCode.EnumsDbContext";
        }

        protected override void Seed(EnumsDbContext context)
        {
            context.UserRoles.AddOrUpdate(
                x => x.Id,
                Enum.GetValues(typeof(UserRoles))
                    .OfType<UserRoles>()
                    .Select(x => new UserRole() { Id = x, Name = x.ToString() })
                    .ToArray());
            // Set a default user
            var user = AddDefaultUser(context);
            context.Users.AddOrUpdate(user);
        }

        private User AddDefaultUser(EnumsDbContext context)
        {
            User user = new User();
            user.Name = "Mohamed Mounnad";
            user.UserRole = context.UserRoles.FirstOrDefault(x => x.Id == UserRoles.Administartor);
            return user;
        }
    }
}
