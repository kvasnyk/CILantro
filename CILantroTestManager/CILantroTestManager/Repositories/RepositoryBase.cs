using CILantroTestManager.Database;
using System;
using System.Threading.Tasks;

namespace CILantroTestManager.Repositories
{
    public abstract class RepositoryBase<TEntity> : IDisposable
        where TEntity : class
    {
        protected readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
        }
    }
}