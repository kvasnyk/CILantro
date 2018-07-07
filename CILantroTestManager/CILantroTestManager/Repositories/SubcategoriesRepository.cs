using CILantroTestManager.Database;
using CILantroTestManager.Entities;

namespace CILantroTestManager.Repositories
{
    public class SubcategoriesRepository : RepositoryBase<SubcategoryEntity>
    {
        public SubcategoriesRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}