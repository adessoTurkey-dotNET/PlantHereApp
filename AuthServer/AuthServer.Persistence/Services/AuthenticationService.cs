using AuthServer.Application.CQRS.Authentication.Commands.RevokeRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser;
using AuthServer.Application.CustomResponses;
using AuthServer.Application.Interfaces.Repositories;
using AuthServer.Application.Interfaces.Services;
using AuthServer.Application.Mapping;
using AuthServer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UdemyAuthServer.Core.UnitOfWork;

namespace AuthServer.Persistence.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly ITokenService _tokenService;

        private readonly UserManager<User> _userManager;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<UserRefreshToken> _userRefreshTokenRepository;


        public AuthenticationService(ITokenService tokenService, UserManager<User> userManager, IUnitOfWork unitOfWork, IRepository<UserRefreshToken> userRefreshTokenRepository)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }

        public async Task<CustomResponse<CreateTokenByUserCommandResponse>> CreateTokenByUser(CreateTokenByUserCommand createTokenByUserCommand)
        {
            if (createTokenByUserCommand == null) throw new ArgumentNullException(nameof(createTokenByUserCommand));

            var user = await _userManager.FindByEmailAsync(createTokenByUserCommand.Email);

            if (user == null) return CustomResponse<CreateTokenByUserCommandResponse>.Fail("Email or Password is wrong", 404, true);

            if (!await _userManager.CheckPasswordAsync(user, createTokenByUserCommand.Password)) return CustomResponse<CreateTokenByUserCommandResponse>.Fail("Email or Password is wrong", 404, true);

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

            await _unitOfWork.CommmitAsync();

            return CustomResponse<CreateTokenByUserCommandResponse>.Success(token, StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<CreateTokenByRefreshTokenCommandResponse>> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenRepository.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null) return CustomResponse<CreateTokenByRefreshTokenCommandResponse>.Fail("Refresh token not found", 404, true);

            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            if (user == null) return CustomResponse<CreateTokenByRefreshTokenCommandResponse>.Fail("User Id not found", 404, true);

            var token = await _tokenService.CreateToken(user);

            existRefreshToken.Code = token.RefreshToken;
            existRefreshToken.Expiration = token.RefreshTokenExpiration;
            await _unitOfWork.CommmitAsync();

            return CustomResponse<CreateTokenByRefreshTokenCommandResponse>.Success(ObjectMapper.Mapper.Map<CreateTokenByRefreshTokenCommandResponse>(token), StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<RevokeRefreshTokenCommandResponse>> RevokeRefreshToken(RevokeRefreshTokenCommand revokeRefreshTokenCommand)
        {
            var existRefreshToken = await _userRefreshTokenRepository.Where(x => x.Code == revokeRefreshTokenCommand.RefleshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null) return CustomResponse<RevokeRefreshTokenCommandResponse>.Fail("Refresh token not found", StatusCodes.Status404NotFound, true);

            _userRefreshTokenRepository.Remove(existRefreshToken);
            await _unitOfWork.CommmitAsync();

            return CustomResponse<RevokeRefreshTokenCommandResponse>.Success(StatusCodes.Status200OK);
        }
    }
}
