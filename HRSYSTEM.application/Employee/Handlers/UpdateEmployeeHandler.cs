using AutoMapper;
using HRSYSTEM.domain;
using HRSYSTEM.persistance.Repositories.Employee;
using MediatR;

namespace HRSYSTEM.application
{
    /// <summary>
    /// This handler will update an employee
    /// </summary>
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDTO>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeDTO> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = _mapper.Map<EmployeeEntity>(request);
                employee.EmployeeID = request.id;
                bool result = await _employeeRepository.UpdateEmployee(employee);

                return _mapper.Map<EmployeeDTO>(employee);
            }
            catch (System.Exception)
            {
                throw new BusinessException("Something went wrong. We can not update the employee.");
            }
            
        }
    }
}
