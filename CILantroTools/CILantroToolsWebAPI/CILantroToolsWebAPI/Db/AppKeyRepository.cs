using CILantroToolsWebAPI.Extensions;
using CILantroToolsWebAPI.ReadModels;
using CILantroToolsWebAPI.Search;
using LinqKit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Db
{
    public class AppKeyRepository<TEntity>
        where TEntity : class, IKeyEntity
    {
        private readonly AppDbContext _context;

        private readonly IServiceProvider _serviceProvider;

        public AppKeyRepository(AppDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<Guid> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public IQueryable<TReadModel> Read<TReadModel>()
            where TReadModel : class, IKeyReadModel
        {
            var mapping = ReadModelMappingsFactory.CreateMapping<TEntity, TReadModel>();
            return _context.Set<TEntity>().AsExpandable().Select(mapping);
        }

        public async Task UpdateAsync(Expression<Func<TEntity, bool>> predicate, Action<TEntity> updateAction)
        {
            var matchingEntities = _context.Set<TEntity>().Where(predicate);

            foreach (var matchingEntity in matchingEntities)
            {
                updateAction(matchingEntity);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var matchingEntities = _context.Set<TEntity>().Where(predicate);

            _context.Set<TEntity>().RemoveRange(matchingEntities);

            await _context.SaveChangesAsync();
        }

        public async Task<SearchResult<TReadModel>> Search<TReadModel>(SearchParameter searchParameter, Expression<Func<TReadModel, bool>> predicate = null)
            where TReadModel : class, IKeyReadModel
        {
            var searchMapper = _serviceProvider.GetRequiredService<SearchMapper<TReadModel>>();

            if (predicate == null)
                predicate = rm => true;

            var baseData = Read<TReadModel>()
                .Where(predicate)
                .Where(CombinePredicates(searchParameter.Filters.Select(f => searchMapper.BuildWhereExpression(f))))
                .OrderBy(searchMapper.BuildOrderByExpression(searchParameter.OrderBy.Property), searchParameter.OrderBy.Direction)
                .ThenBy(searchMapper.BuildThenByExpression(searchParameter.OrderBy2?.Property), searchParameter.OrderBy2?.Direction)
                .ThenBy(searchMapper.BuildThenByExpression(searchParameter.OrderBy3?.Property), searchParameter.OrderBy3?.Direction);

            var count = baseData.Count();

            var data = baseData
                .Skip(searchParameter.PageSize * (searchParameter.PageNumber - 1))
                .Take(searchParameter.PageSize);

            var result = new SearchResult<TReadModel>
            {
                Data = data.ToList(),
                Count = count
            };

            return result;
        }

        private Expression<Func<TReadModel, bool>> CombinePredicates<TReadModel>(IEnumerable<Expression<Func<TReadModel, bool>>> predicates)
            where TReadModel : class, IKeyReadModel
        {
            Expression<Func<TReadModel, bool>> resultPredicate = rm => true;
            foreach (var predicate in predicates)
            {
                var expr = Expression.AndAlso(resultPredicate.Body, Expression.Invoke(predicate, resultPredicate.Parameters));
                resultPredicate = Expression.Lambda<Func<TReadModel, bool>>(expr, resultPredicate.Parameters);
            }

            return resultPredicate;
        }
    }
}