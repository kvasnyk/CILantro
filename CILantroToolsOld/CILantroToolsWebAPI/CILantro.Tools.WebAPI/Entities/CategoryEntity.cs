using System;
using System.Collections.Generic;

namespace CILantro.Tools.WebAPI.Entities
{
    public class CategoryEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public virtual ICollection<SubcategoryEntity> Subcategories { get; set; }
    }
}