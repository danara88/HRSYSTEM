using MediatR;
namespace HRSYSTEM.application
{
    public class LoginUserCommand : IRequest<AuthResponseDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
