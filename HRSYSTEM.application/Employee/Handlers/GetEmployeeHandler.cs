using AutoMapper;
using HRSYSTEM.persistance.Repositories.Employee;
using MediatR;

namespace HRSYSTEM.application
{
    /// <summary>
    /// Get an employee by ID handler
    /// </summary>
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeQuery, EmployeeDTO>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeDTO> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployee(request.id);
            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            return employeeDTO;
        }
    }
}
