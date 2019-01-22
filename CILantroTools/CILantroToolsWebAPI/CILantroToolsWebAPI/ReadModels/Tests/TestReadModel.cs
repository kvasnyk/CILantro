using CILantroToolsWebAPI.DbModels;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.ReadModels.Tests
{
    public class TestReadModel : IKeyReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }
    }

    public class TestReadModelMapping : ReadModelMappingBase<Test, TestReadModel>
    {
        public override Expression<Func<Test, TestReadModel>> Mapping => test => new TestReadModel
        {
            Id = test.Id,
            Name = test.Name,
            Path = test.Path
        };
    }
}