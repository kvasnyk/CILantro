using CILantroTestManager.Database;
using CILantroTestManager.Entities;

namespace CILantroTestManager.Repositories
{
    public class CategoriesRepository : RepositoryBase<CategoryEntity>
    {
        public CategoriesRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}