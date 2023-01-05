using AuthServer.Application.CustomResponses;
using MediatR;

namespace AuthServer.Application.CQRS.Authentication.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommand : IRequest<CustomResponse<RevokeRefreshTokenCommandResponse>>
    {
        public string RefleshToken { get; set; }


        public RevokeRefreshTokenCommand(string refleshToken)
        {
            RefleshToken = refleshToken;
        }
    }
}
