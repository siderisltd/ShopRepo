namespace Eshop.Web
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EshopDbContext, Configuration>());
            EshopDbContext.Create().Database.Initialize(true);
        }
    }
}