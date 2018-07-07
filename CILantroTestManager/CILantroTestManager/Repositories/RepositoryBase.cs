using CILantroTestManager.Database;
using System;
using System.Linq;

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

        public void CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> ReadAllAsync()
        {
            return _context.Set<TEntity>();
        }

        public void Dispose()
        {
        }
    }
}