using System.Data.Entity.Migrations;

namespace CILantroTestManager.Database
{
    public class ApplicationDbMigrationsConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public ApplicationDbMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            CommandTimeout = 1000;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);
        }
    }
}