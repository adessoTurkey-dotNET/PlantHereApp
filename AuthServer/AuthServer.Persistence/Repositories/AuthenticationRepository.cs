using AuthServer.Application.CQRS.Authentication.Commands.RevokeRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser;
using AuthServer.Application.Exceptions;
using AuthServer.Application.Interfaces.Repositories;
using AuthServer.Application.Interfaces.Services;
using AuthServer.Application.Mapping;
using AuthServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UdemyAuthServer.Core.UnitOfWork;

namespace AuthServer.Persistence.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {

        private readonly ITokenService _tokenService;

        private readonly UserManager<User> _userManager;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<UserRefreshToken> _userRefreshTokenRepository;

        public AuthenticationRepository(ITokenService tokenService, UserManager<User> userManager, IUnitOfWork unitOfWork, IRepository<UserRefreshToken> userRefreshTokenRepository)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }

        public async Task<CreateTokenByUserCommandResponse> CreateTokenByUser(CreateTokenByUserCommand createTokenByUserCommand)
        {
            if (createTokenByUserCommand == null) throw new ArgumentNullException(nameof(createTokenByUserCommand));

            var user = await _userManager.FindByEmailAsync(createTokenByUserCommand.Email);

            if (user == null) throw new NotFoundException("Email or Password is wrong");

            if (!await _userManager.CheckPasswordAsync(user, createTokenByUserCommand.Password)) throw new NotFoundException("Email or Password is wrong");

            var token = await _tokenService.CreateToken(user);

            var userRefreshToken = await _userRefreshTokenRepository.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

            if (userRefreshToken == null)
            {
                await _userRefreshTokenRepository.AddAsync(
                    new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }

            return token;
        }

        public async Task<CreateTokenByRefreshTokenCommandResponse> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenRepository.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null) throw new NotFoundException("Refresh token not found");

            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            if (user == null) throw new NotFoundException("User Id not found");

            var token = await _tokenService.CreateToken(user);

            existRefreshToken.Code = token.RefreshToken;
            existRefreshToken.Expiration = token.RefreshTokenExpiration;

            return ObjectMapper.Mapper.Map<CreateTokenByRefreshTokenCommandResponse>(token);
        }

        public async Task<bool> RevokeRefreshToken(RevokeRefreshTokenCommand revokeRefreshTokenCommand)
        {
            var existRefreshToken = await _userRefreshTokenRepository.Where(x => x.Code == revokeRefreshTokenCommand.RefleshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null) throw new NotFoundException("Refresh token not found");

            _userRefreshTokenRepository.Remove(existRefreshToken);

            return true;
        }
    }
}
