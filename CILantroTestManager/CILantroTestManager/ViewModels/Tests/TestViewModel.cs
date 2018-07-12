using System;

namespace CILantroTestManager.ViewModels.Tests
{
    public class TestViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ShortPath { get; set; }

        public string CategoryName { get; set; }

        public string SubcategoryName { get; set; }

        public bool IsIlSourceAvailable { get; set; }
    }
}