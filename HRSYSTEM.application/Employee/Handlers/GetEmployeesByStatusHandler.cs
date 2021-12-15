using AutoMapper;
using HRSYSTEM.persistance.Repositories.Employee;
using MediatR;

namespace HRSYSTEM.application
{
    /// <summary>
    /// This handler will return the employees depending of their status
    /// </summary>
    public class GetEmployeesByStatusHandler : IRequestHandler<GetEmployeesByStatusQuery, IEnumerable<GetEmployeesDTO>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public GetEmployeesByStatusHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<GetEmployeesDTO>> Handle(GetEmployeesByStatusQuery request, CancellationToken cancellationToken)
        {
            if (request.Status == 0 || request.Status == 1 || request.Status == 2)
            {
                var employees = await _employeeRepository.GetEmployeesByStatus(request.Status);
                return _mapper.Map<IEnumerable<GetEmployeesDTO>>(employees);
            } 
            throw new Exception("Invalid status option");
        }
    }
}
