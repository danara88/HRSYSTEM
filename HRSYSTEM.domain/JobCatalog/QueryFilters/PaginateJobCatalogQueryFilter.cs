namespace HRSYSTEM.domain
{
    public class PaginateJobCatalogQueryFilter
    {
        public string? JobTitle { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
