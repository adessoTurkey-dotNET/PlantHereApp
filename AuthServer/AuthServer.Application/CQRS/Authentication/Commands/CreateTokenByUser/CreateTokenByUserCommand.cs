using AuthServer.Application.CustomResponses;
using MediatR;

namespace AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser
{
    public class CreateTokenByUserCommand : IRequest<CustomResponse<CreateTokenByUserCommandResponse>>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public CreateTokenByUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
