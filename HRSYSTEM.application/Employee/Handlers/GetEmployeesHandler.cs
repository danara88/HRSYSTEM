using AutoMapper;
using HRSYSTEM.persistance.Repositories.Employee;
using MediatR;

namespace HRSYSTEM.application
{
    /// <summary>
    /// Get all employees handler
    /// </summary>
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<GetEmployeesDTO>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public GetEmployeesHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<GetEmployeesDTO>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetEmployees();
            var employeesDTO = _mapper.Map<IEnumerable<GetEmployeesDTO>>(employees);
            return employeesDTO;
        }
    }
}
