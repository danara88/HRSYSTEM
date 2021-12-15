using MediatR;

namespace HRSYSTEM.application
{
    public class UpdateEmployeeCommand : EmployeeDTO, IRequest<EmployeeDTO>
    {
        public int id { get; set; }
        public UpdateEmployeeCommand(int employeeId)
        {
            id = employeeId;
        }
    }
}
