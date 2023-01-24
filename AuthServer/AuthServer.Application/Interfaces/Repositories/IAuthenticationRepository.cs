using AuthServer.Application.CQRS.Authentication.Commands.RevokeRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser;

namespace AuthServer.Application.Interfaces.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<CreateTokenByUserCommandResponse> CreateTokenByUser(CreateTokenByUserCommand getTokenQuery);

        Task<CreateTokenByRefreshTokenCommandResponse> CreateTokenByRefreshToken(string refreshToken);

        Task<bool> RevokeRefreshToken(RevokeRefreshTokenCommand revokeRefreshTokenCommand);
    }
}