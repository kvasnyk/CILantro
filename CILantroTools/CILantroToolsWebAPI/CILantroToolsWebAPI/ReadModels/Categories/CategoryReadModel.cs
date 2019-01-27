using System;

namespace CILantroToolsWebAPI.ReadModels.Categories
{
    public class CategoryReadModel : IKeyReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}