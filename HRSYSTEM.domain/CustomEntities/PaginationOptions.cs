namespace HRSYSTEM.domain
{
    /// <summary>
    /// PaginationOptions for results pagination
    /// </summary>
    public class PaginationOptions
    {
        /// <summary>
        /// Default page size. How many items in one page
        /// </summary>
        public int DefaultPageSize { get; set; }
        
        /// <summary>
        /// Page number of the pagination by default
        /// </summary>
        public int DefaultPageNumber { get; set; }
    }
}
