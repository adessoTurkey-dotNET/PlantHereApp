using AuthServer.Application.CustomResponses;
using MediatR;

namespace AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken
{
    public class CreateTokenByRefreshTokenCommand : IRequest<CustomResponse<CreateTokenByRefreshTokenCommandResponse>>
    {
        public string RefreshToken { get; set; }

    }
}
