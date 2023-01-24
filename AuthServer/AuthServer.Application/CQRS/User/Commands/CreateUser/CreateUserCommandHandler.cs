using AuthServer.Application.Interfaces.Repositories;
using AuthServer.Application.Mapping;
using DotNetCore.CAP;
using MediatR;
using UdemyAuthServer.Core.UnitOfWork;

namespace AuthServer.Application.CQRS.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        private readonly ICapPublisher _capPublisher;

        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, ICapPublisher capPublisher,IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _capPublisher = capPublisher;
            _unitOfWork = unitOfWork;
        }


        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = ObjectMapper.Mapper.Map<CreateUserCommandResponse>(await _userRepository.CreateUserAsync(request));
            await _unitOfWork.CommmitAsync();
            await _capPublisher.PublishAsync<string>("createUser.transaction", result.Id);
            return result;
        }
    }
}
