using System;

namespace CILantroTestManager.Entities
{
    public class TestEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public Guid CategoryId { get; set; }

        public virtual CategoryEntity Category { get; set; }

        public Guid SubcategoryId { get; set; }

        public virtual SubcategoryEntity Subcategory { get; set; }
    }
}