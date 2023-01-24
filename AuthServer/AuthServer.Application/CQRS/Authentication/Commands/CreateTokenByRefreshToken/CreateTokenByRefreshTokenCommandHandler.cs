using AuthServer.Application.Interfaces.Repositories;
using MediatR;
using UdemyAuthServer.Core.UnitOfWork;

namespace AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken
{
    public class CreateTokenByRefreshTokenCommandHandler : IRequestHandler<CreateTokenByRefreshTokenCommand, CreateTokenByRefreshTokenCommandResponse>
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CreateTokenByRefreshTokenCommandHandler(IAuthenticationRepository authenticationRepository,IUnitOfWork unitOfWork)
        {
            _authenticationRepository = authenticationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateTokenByRefreshTokenCommandResponse> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationRepository.CreateTokenByRefreshToken(request.RefreshToken);

            await _unitOfWork.CommmitAsync();

            return result;

        }
    }
}
