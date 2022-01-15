using HRSYSTEM.domain;
using MediatR;

namespace HRSYSTEM.application
{
    public class GetJobCatalogsQuery : IRequest<PagedList<JobCatalogDTO>>
    {
        public PaginateJobCatalogQueryFilter Filters { get; set; }
        public GetJobCatalogsQuery(PaginateJobCatalogQueryFilter filters)
        {
            Filters = filters;
        }
    }
}
