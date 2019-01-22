using System;

namespace CILantroToolsWebAPI.Db
{
    public interface IKeyEntity
    {
        Guid Id { get; set; }
    }
}