using System.Collections.Generic;

namespace CILantroToolsWebAPI.Search
{
    public class SearchFilter
    {
        public string Property { get; set; }

        public SearchFilterType Type { get; set; }

        public string Value { get; set; }

        public List<string> Values { get; set; }
    }
}