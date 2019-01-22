using System;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Db
{
    public class AppKeyRepository<TEntity>
        where TEntity : class, IKeyEntity
    {
        private readonly AppDbContext _context;

        public AppKeyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }
}