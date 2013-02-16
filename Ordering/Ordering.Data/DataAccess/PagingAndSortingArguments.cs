namespace Ordering.Data.DataAccess
{
    public struct PagingAndSortingArguments
    {
        public PagingAndSortingArguments(int firstResult, int maxResults, string sortExpression) : this()
        {
            this.FirstResult = firstResult;
            this.MaxResults = maxResults;
            this.SortExpression = sortExpression;
        }

        public int FirstResult { get; set; }

        public int MaxResults { get; set; }

        public string SortExpression { get; set; }
    }
}