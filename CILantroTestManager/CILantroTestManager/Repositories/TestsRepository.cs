using CILantroTestManager.Database;
using CILantroTestManager.Entities;
using System.Data.Entity;
using System.Linq;

namespace CILantroTestManager.Repositories
{
    public class TestsRepository : RepositoryBase<TestEntity>
    {
        public TestsRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override IQueryable<TestEntity> ReadAll()
        {
            return _context.Tests
                .Include(t => t.Category)
                .Include(t => t.Subcategory);
        }
    }
}