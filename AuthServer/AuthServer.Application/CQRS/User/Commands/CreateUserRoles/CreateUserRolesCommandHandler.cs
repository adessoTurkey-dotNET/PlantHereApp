﻿using AuthServer.Application.CustomResponses;
using AuthServer.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.CQRS.User.Commands.CreateUserRoles
{
    public class CreateUserRolesCommandHandler : IRequestHandler<CreateUserRolesCommand, CustomResponse<CreateUserRolesCommandResponse>>
    {
        private readonly IUserService _userService;

        public CreateUserRolesCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CustomResponse<CreateUserRolesCommandResponse>> Handle(CreateUserRolesCommand request, CancellationToken cancellationToken)
        {
            return await _userService.CreateUserRoles(request);
        }
    }
}