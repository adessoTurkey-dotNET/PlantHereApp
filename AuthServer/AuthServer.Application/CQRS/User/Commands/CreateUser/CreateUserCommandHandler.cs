using AuthServer.Application.CustomResponses;
using AuthServer.Application.Interfaces.Services;
using MediatR;

namespace AuthServer.Application.CQRS.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CustomResponse<CreateUserCommandResponse>>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CustomResponse<CreateUserCommandResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.CreateUserAsync(request);
        }
    }
}
