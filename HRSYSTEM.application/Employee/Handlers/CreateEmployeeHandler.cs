using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRSYSTEM.domain;
using HRSYSTEM.persistance.Repositories.Employee;
using MediatR;

namespace HRSYSTEM.application
{
    /// <summary>
    /// Create a new employee handler
    /// </summary>
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeDTO>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public CreateEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        public async Task<CreateEmployeeDTO> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = _mapper.Map<EmployeeEntity>(request);
                await _employeeRepository.CreateEmployee(employee);

                return _mapper.Map<CreateEmployeeDTO>(employee);
            }
            catch(System.Exception)
            {
                throw new BusinessException("Something went wrong. We can not create the employee.");
            }

        }
    }
}
