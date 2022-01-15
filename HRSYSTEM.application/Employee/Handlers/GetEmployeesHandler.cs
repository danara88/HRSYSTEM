using AutoMapper;
using HRSYSTEM.persistance.Repositories.Employee;
using HRSYSTEM.domain;
using MediatR;
using System.Linq;
using Microsoft.Extensions.Options;

namespace HRSYSTEM.application
{
    /// <summary>
    /// Get all employees handler
    /// </summary>
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, PagedList<GetEmployeesDTO>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly PaginationOptions _paginationOptions;
        private readonly IMapper _mapper;
        public GetEmployeesHandler(IEmployeeRepository employeeRepository, IMapper mapper, IOptions<PaginationOptions> options)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _paginationOptions = options.Value;
        }
        public async Task<PagedList<GetEmployeesDTO>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            request.Filters.PageNumber = request.Filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : request.Filters.PageNumber;
            request.Filters.PageSize = request.Filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : request.Filters.PageSize;

            var employees = await _employeeRepository.GetEmployees();

            if (request.Filters.FirstName != null)
            {
                employees = employees.Where(x => x.FirstName.ToLower().Contains(request.Filters.FirstName.ToLower()));
            }

            if (request.Filters.LastName != null)
            {
                employees = employees.Where(x => x.LastName.ToLower().Contains(request.Filters.LastName.ToLower()));
            }

            if (request.Filters.Status != null)
            {
                employees = employees.Where(x => x.Status.GetHashCode() == request.Filters.Status);
            }

            var employeesDTO = _mapper.Map<IEnumerable<GetEmployeesDTO>>(employees);

            PagedList<GetEmployeesDTO> pagedEmployees = PagedList<GetEmployeesDTO>
                                            .Create(employeesDTO, request.Filters.PageNumber, request.Filters.PageSize);
            return pagedEmployees;
        }
    }
}
