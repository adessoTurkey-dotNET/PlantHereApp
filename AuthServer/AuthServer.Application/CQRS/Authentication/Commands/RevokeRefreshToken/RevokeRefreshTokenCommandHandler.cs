using AuthServer.Application.CustomResponses;
using AuthServer.Application.Interfaces.Services;
using MediatR;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.CQRS.Authentication.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommandHandler : IRequestHandler<RevokeRefreshTokenCommand, CustomResponse<RevokeRefreshTokenCommandResponse>>
    {
        private readonly IAuthenticationService _authenticationService;

        public RevokeRefreshTokenCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<CustomResponse<RevokeRefreshTokenCommandResponse>> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RevokeRefreshToken(request);

        }
    }
}
