using MediatR;

namespace HRSYSTEM.application
{
    public class GetEmployeesByStatusQuery : IRequest<IEnumerable<GetEmployeesDTO>>
    {
        public int Status { get; set; }
        public GetEmployeesByStatusQuery(int _status)
        {
            Status = _status;
        }
    }
}
