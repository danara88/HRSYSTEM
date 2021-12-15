using MediatR;

namespace HRSYSTEM.application
{
    public class CreateEmployeeCommand : CreateEmployeeDTO, IRequest<CreateEmployeeDTO>
    {
    }
}
