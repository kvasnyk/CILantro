﻿using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.Enums;
using System;

namespace CILantroToolsWebAPI.DbModels
{
    public class Run : IKeyEntity
    {
        public Guid Id { get; set; }

        public RunType Type { get; set; }
    }
}