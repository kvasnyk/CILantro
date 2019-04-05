namespace CILantroToolsWebAPI.Search
{
    public class SearchParameter
    {
        public SearchOrderParameter OrderBy { get; set; }

        public SearchOrderParameter OrderBy2 { get; set; }

        public SearchOrderParameter OrderBy3 { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}