using System.Data.Entity;

namespace CILantroTestManager.Database
{
    public class ApplicationDbInitializer : MigrateDatabaseToLatestVersion<ApplicationDbContext, ApplicationDbMigrationsConfiguration>
    {
        public ApplicationDbInitializer(bool useSuppliedContext)
            : base(useSuppliedContext)
        { 
        }
    }
}