﻿using CILantro.Structure;
using System.Collections.Generic;

namespace CILantro.Parsing
{
    public class CilParserResult
    {
        public CilParserStatus Status { get; set; }

        public List<string> Errors { get; set; }

        public CilProgram Program { get; set; }
    }
}