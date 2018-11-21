﻿using CILantro.Tools.WebAPI.Entities;
using CILantro.Tools.WebAPI.ReadModels;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CILantro.Tools.WebAPI.Database.Repositories
{
    public class CategoriesRepository : RepositoryBase<CategoryEntity, CategoryReadModel, CategorySearchReadModel>
    {
        public CategoriesRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        protected override Expression<Func<CategoryEntity, CategorySearchReadModel>> ToSearchReadModelMapping =>
            category => new CategorySearchReadModel
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code,
                Subcategories = category.Subcategories.Select(subcategory => new SubcategorySearchReadModel
                {
                    Id = subcategory.Id,
                    Name = subcategory.Name,
                    Code = subcategory.Code
                }).OrderBy(subcategory => subcategory.Name).ToList()
            };

        protected override Expression<Func<CategorySearchReadModel, string>> MapSearchPropertyToValue(string searchProperty)
        {
            switch(searchProperty.ToLower())
            {
                case "id":
                    return x => x.Id.ToString();
                case "name":
                    return x => x.Name.ToString();
                default:
                    return x => x.Id.ToString();
            }
        }
    }
}