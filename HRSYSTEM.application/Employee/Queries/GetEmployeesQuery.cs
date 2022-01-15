using MediatR;
using HRSYSTEM.domain;

namespace HRSYSTEM.application
{
    public class GetEmployeesQuery : IRequest<PagedList<GetEmployeesDTO>>
    {
        public PaginateEmployeeQueryFilter Filters { get; set; }
        public GetEmployeesQuery(PaginateEmployeeQueryFilter filters)
        {
            Filters = filters;
        }
    }
}
