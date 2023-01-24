using AuthServer.Application.Interfaces.Repositories;
using MediatR;

namespace AuthServer.Application.CQRS.Authentication.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommandHandler : IRequestHandler<RevokeRefreshTokenCommand, RevokeRefreshTokenCommandResponse>
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public RevokeRefreshTokenCommandHandler(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<RevokeRefreshTokenCommandResponse> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            await _authenticationRepository.RevokeRefreshToken(request);
            return new RevokeRefreshTokenCommandResponse();

        }
    }
}
