using MediatR;

namespace HRSYSTEM.application
{
    public class UpdateEmployeeCommand : UpdateEmployeeDTO, IRequest<EmployeeDTO>
    {
    }
}
