using System;
using System.Threading.Tasks;

namespace CILantro.Tools.WebAPI.Database.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable
        where TEntity : class
    {
        protected readonly ApplicationDbContext _context;

        protected RepositoryBase(ApplicationDbContext context)
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