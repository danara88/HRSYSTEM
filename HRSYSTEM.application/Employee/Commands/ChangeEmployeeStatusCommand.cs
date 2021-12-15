using MediatR;

namespace HRSYSTEM.application
{
    public class ChangeEmployeeStatusCommand : IRequest<EmployeeDTO>
    {
        public int EmployeeID { get; set; }
        public int Status  { get; set; }

    }
}
