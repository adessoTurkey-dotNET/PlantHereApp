using AuthServer.Application.CQRS.Authentication.Commands.RevokeRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser;

using AuthServer.Application.CustomResponses;

namespace AuthServer.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<CustomResponse<CreateTokenByUserCommandResponse>> CreateTokenByUser(CreateTokenByUserCommand getTokenQuery);

        Task<CustomResponse<CreateTokenByRefreshTokenCommandResponse>> CreateTokenByRefreshToken(string refreshToken);

        Task<CustomResponse<RevokeRefreshTokenCommandResponse>> RevokeRefreshToken(RevokeRefreshTokenCommand revokeRefreshTokenCommand);
    }
}