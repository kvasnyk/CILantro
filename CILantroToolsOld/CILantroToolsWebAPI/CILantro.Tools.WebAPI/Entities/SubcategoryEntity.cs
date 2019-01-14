using System;

namespace CILantro.Tools.WebAPI.Entities
{
    public class SubcategoryEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public Guid CategoryId { get; set; }

        public virtual CategoryEntity Category { get; set; }
    }
}