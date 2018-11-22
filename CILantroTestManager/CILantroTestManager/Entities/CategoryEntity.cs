﻿using System;
using System.Collections.Generic;

namespace CILantroTestManager.Entities
{
    public class CategoryEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<SubcategoryEntity> Subcategories { get; set; }
    }
}