﻿using System;
using System.Collections.Generic;

namespace CILantroTestManager.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SubcategoryViewModel> Subcategories { get; set; }
    }
}