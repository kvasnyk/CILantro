using CILantro.Tools.WebAPI.Search;
using LinqKit;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CILantro.Tools.WebAPI.Database.Repositories
{
    public abstract class RepositoryBase<TEntity, TReadModel, TSearchReadModel> : IDisposable
        where TEntity : class
    {
        protected readonly ApplicationDbContext _context;

        protected RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        protected abstract Expression<Func<TEntity, TSearchReadModel>> ToSearchReadModelMapping { get; }

        protected abstract Expression<Func<TSearchReadModel, string>> MapSearchPropertyToValue(string searchProperty);

        public async Task CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<SearchResult<TSearchReadModel>> Search(SearchParameter searchParam)
        {
            var order = searchParam.Order ?? "asc";
            var orderBy = searchParam.OrderBy ?? string.Empty;

            var results = AsSearchReadModel(_context.Set<TEntity>());

            var orderByValue = MapSearchPropertyToValue(orderBy);

            var orderedResults = order.ToLower().Equals("asc") ?
                results.OrderBy(orderByValue) :
                results.OrderByDescending(orderByValue);

            return new SearchResult<TSearchReadModel>
            {
                Results = await orderedResults.ToListAsync()
            };
        }

        public void Dispose()
        {
        }

        private Expression<Func<TEntity, TSearchReadModel>> GetSearchReadModelMapping()
        {
            return ToSearchReadModelMapping.Expand();
        }

        private IQueryable<TSearchReadModel> AsSearchReadModel(IQueryable<TEntity> source)
        {
            var mapping = GetSearchReadModelMapping();
            return source.AsExpandable().Select(mapping);
        }
    }
}