using CILantroToolsWebAPI.DbModels;
using System;
using System.Linq.Expressions;

namespace CILantroToolsWebAPI.ReadModels.Tests
{
    public class TestIoExampleReadModel : IKeyReadModel
    {
        public Guid Id { get; set; }

        public Guid TestId { get; set; }

        public string Name { get; set; }

        public string Input { get; set; }

        public string Output { get; set; }
    }

    public class TestIoExampleReadModelMapping : ReadModelMappingBase<TestInputOutputExample, TestIoExampleReadModel>
    {
        public override Expression<Func<TestInputOutputExample, TestIoExampleReadModel>> Mapping => testIoExample => new TestIoExampleReadModel
        {
            Id = testIoExample.Id,
            TestId = testIoExample.TestId,
            Name = testIoExample.Name,
            Input = testIoExample.Input,
            Output = testIoExample.Output
        };
    }
}