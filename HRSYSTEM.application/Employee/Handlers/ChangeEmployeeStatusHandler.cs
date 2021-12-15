using AutoMapper;
using HRSYSTEM.domain;
using HRSYSTEM.persistance.Repositories.Employee;
using MediatR;

namespace HRSYSTEM.application.Employee.Handlers
{
    /// <summary>
    /// This handler terminates an employee
    /// </summary>
    public class ChangeEmployeeStatusHandler : IRequestHandler<ChangeEmployeeStatusCommand, EmployeeDTO>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public ChangeEmployeeStatusHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeDTO> Handle(ChangeEmployeeStatusCommand request, CancellationToken cancellationToken)
        {
            EmployeeEntity? employee = await _employeeRepository.GetEmployee(request.EmployeeID);
            if (employee == null) throw new Exception("The employee does not exist");

            employee.EmployeeID = request.EmployeeID;

            bool updateEmployee = await _employeeRepository.UpdateStatusEmployee(employee, request.Status);
            if (!updateEmployee) throw new Exception("Employee was not updated.");

            return _mapper.Map<EmployeeDTO>(employee);
        }
    }
}
