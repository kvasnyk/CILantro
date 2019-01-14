using System.Collections.Generic;

namespace CILantro.Tools.WebAPI.Search
{
    public class SearchResult<TSearchReadModel>
    {
        public List<TSearchReadModel> Results { get; set; }
    }
}