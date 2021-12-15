using MediatR;

namespace HRSYSTEM.application
{
    public class GetEmployeesQuery : IRequest<IEnumerable<GetEmployeesDTO>>
    {

    }
}
