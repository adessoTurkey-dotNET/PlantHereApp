using AuthServer.Application.Interfaces.Repositories;
using MediatR;
using UdemyAuthServer.Core.UnitOfWork;

namespace AuthServer.Application.CQRS.User.Commands.CreateUserRoles
{
    public class CreateUserRolesCommandHandler : IRequestHandler<CreateUserRolesCommand, CreateUserRolesCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CreateUserRolesCommandHandler(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUserRolesCommandResponse> Handle(CreateUserRolesCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.CreateUserRoles(request);
            await _unitOfWork.CommmitAsync();
            return new CreateUserRolesCommandResponse();
        }
    }
}
