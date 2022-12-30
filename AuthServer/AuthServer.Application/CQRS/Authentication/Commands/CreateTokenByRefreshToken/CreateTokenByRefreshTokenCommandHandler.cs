﻿using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken;
using AuthServer.Application.CustomResponses;
using AuthServer.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken
{
    public class CreateTokenByRefreshTokenCommandHandler : IRequestHandler<CreateTokenByRefreshTokenCommand, CustomResponse<CreateTokenByRefreshTokenCommandResponse>>
    {
        private readonly IAuthenticationService _authenticationService;

        public CreateTokenByRefreshTokenCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<CustomResponse<CreateTokenByRefreshTokenCommandResponse>> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationService.CreateTokenByRefreshToken(request.RefreshToken);
        }
    }
}