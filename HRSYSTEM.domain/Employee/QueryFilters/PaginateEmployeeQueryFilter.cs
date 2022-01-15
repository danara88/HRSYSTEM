namespace HRSYSTEM.domain
{
    public class PaginateEmployeeQueryFilter
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Status { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
