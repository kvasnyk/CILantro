using CILantroTestManager.Database;
using CILantroTestManager.Entities;

namespace CILantroTestManager.Repositories
{
    public class TestsRepository : RepositoryBase<TestEntity>
    {
        public TestsRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}