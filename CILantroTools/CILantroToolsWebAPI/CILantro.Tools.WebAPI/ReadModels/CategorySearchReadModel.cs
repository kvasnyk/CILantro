﻿using System;
using System.Collections.Generic;

namespace CILantro.Tools.WebAPI.ReadModels
{
    public class CategorySearchReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public List<SubcategorySearchReadModel> Subcategories { get; set; }
    }
}