using CILantroTestManager.ViewModels.Categories;
using System;
using System.Collections.Generic;

namespace CILantroTestManager.ViewModels.Tests
{
    public class TestsAddViewModel
    {
        public string TestName { get; set; }

        public Guid CategoryId { get; set; }

        public Guid SubcategoryId { get; set; }

        public IEnumerable<CategoryViewModel> AllCategories { get; set; }
    }
}