using System.Data.Entity;

namespace CILantro.Tools.WebAPI.Database
{
    public class ApplicationDbInitializer : MigrateDatabaseToLatestVersion<ApplicationDbContext, ApplicationDbMigrationsConfiguration>
    {
        public ApplicationDbInitializer(bool useSuppliedContext)
            : base(useSuppliedContext)
        {
        }
    }
}