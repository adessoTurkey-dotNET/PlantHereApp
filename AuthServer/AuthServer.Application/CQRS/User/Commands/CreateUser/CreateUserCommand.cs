using AuthServer.Application.CustomResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.CQRS.User.Commands.CreateUser
{
    public class CreateUserCommand :IRequest<CustomResponse<CreateUserCommandResponse>>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
     
        public string Email { get; set; }
    }
}
