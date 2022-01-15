using MediatR;

namespace HRSYSTEM.application.Auth.Handler
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, AuthResponseDTO>
    {
        public Task<AuthResponseDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
