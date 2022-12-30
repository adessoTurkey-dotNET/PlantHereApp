﻿using AuthServer.Application.CQRS.User.Commands.CreateUser;
using AuthServer.Application.CQRS.User.Commands.CreateUserRoles;
using AuthServer.Application.CQRS.User.Queries.GetUserByName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AuthServer.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand)
        {
            return ActionResultInstance(await _mediator.Send(createUserCommand));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return ActionResultInstance(await _mediator.Send(new GetUserByNameQuery(HttpContext.User.Identity.Name)));
        }

        [Authorize(Roles ="superadmin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUserRoles(CreateUserRolesCommand createUserRolesCommand)
        {
            return ActionResultInstance(await _mediator.Send(createUserRolesCommand));
        }
    }
}