﻿using CILantroToolsWebAPI.ReadModels;
using LinqKit;
using System;
using System.Linq;
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

        public IQueryable<TReadModel> Read<TReadModel>()
            where TReadModel : class, IKeyReadModel
        {
            var mapping = ReadModelMappingsFactory.CreateMapping<TEntity, TReadModel>();
            return _context.Set<TEntity>().AsExpandable().Select(mapping);
        }
    }
}