using AuthServer.Application.CustomResponses;
using AuthServer.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser
{
    public class CreateTokenByUserCommandHandler : IRequestHandler<CreateTokenByUserCommand, CustomResponse<CreateTokenByUserCommandResponse>>
    {
        private readonly IAuthenticationService _authenticationService;

        public CreateTokenByUserCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<CustomResponse<CreateTokenByUserCommandResponse>> Handle(CreateTokenByUserCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationService.CreateTokenByUser(request);
        }
    }
}
