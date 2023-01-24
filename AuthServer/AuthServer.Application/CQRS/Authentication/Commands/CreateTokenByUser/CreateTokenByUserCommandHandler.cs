using AuthServer.Application.Interfaces.Repositories;
using MediatR;
using UdemyAuthServer.Core.UnitOfWork;

namespace AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser
{
    public class CreateTokenByUserCommandHandler : IRequestHandler<CreateTokenByUserCommand, CreateTokenByUserCommandResponse>
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CreateTokenByUserCommandHandler(IAuthenticationRepository authenticationRepository,IUnitOfWork unitOfWork)
        {
            _authenticationRepository = authenticationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateTokenByUserCommandResponse> Handle(CreateTokenByUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationRepository.CreateTokenByUser(request);
            await _unitOfWork.CommmitAsync();
            return result;
        }
    }
}
