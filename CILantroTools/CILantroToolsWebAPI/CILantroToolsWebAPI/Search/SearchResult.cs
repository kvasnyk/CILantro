using System.Collections.Generic;

namespace CILantroToolsWebAPI.Search
{
    public class SearchResult<TReadModel>
    {
        public IEnumerable<TReadModel> Data { get; set; }

        public int Count { get; set; }
    }
}