using MediatR;

namespace HRSYSTEM.application
{
    public class GetEmployeeQuery : IRequest<EmployeeDTO>
    {
        public int id { get; set; }
        public GetEmployeeQuery(int employeeID)
        {
            id = employeeID;
        }
    }
}
