using CILantro.Tools.WebAPI.Entities;

namespace CILantro.Tools.WebAPI.Database.Repositories
{
    public class CategoriesRepository : RepositoryBase<CategoryEntity>
    {
        public CategoriesRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}