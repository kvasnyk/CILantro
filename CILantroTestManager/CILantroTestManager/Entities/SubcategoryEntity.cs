using System;

namespace CILantroTestManager.Entities
{
    public class SubcategoryEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public virtual CategoryEntity Category { get; set; }
    }
}