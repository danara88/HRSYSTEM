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
                var existEmployee = await _employeeRepository.GetEmployee(request.EmployeeID);
                if (existEmployee != null)
                {
                    UpdateEmployeeDTO employeeToUpdate = new UpdateEmployeeDTO
                    {
                        EmployeeID = request.EmployeeID,
                        FirstName = request.FirstName,
                        MiddleName = request.MiddleName,
                        LastName = request.LastName,
                        JobCatalogID = request.JobCatalogID,
                        WorkEmail = request.WorkEmail,
                        Telephone = request.Telephone,
                        Status = request.Status,
                    };

                    var employee = _mapper.Map<EmployeeEntity>(employeeToUpdate);
                
                    bool result = await _employeeRepository.UpdateEmployee(employee);

                    return _mapper.Map<EmployeeDTO>(employee);
                } else
                {
                    throw new BusinessException("The employee does'nt exist.");
                }
            }
            catch (System.Exception)
            {
                throw new BusinessException("Something went wrong. We can not update the employee.");
            }
            
        }
    }
}
