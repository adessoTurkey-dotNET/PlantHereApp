using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser;
using AuthServer.Application.CQRS.User.Commands.CreateUser;
using AuthServer.Application.CQRS.User.Commands.CreateUserRoles;
using AuthServer.Application.CQRS.User.Queries.GetUserByName;
using AuthServer.Domain.Entities;
using DotNetCore.CAP;
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

        private readonly ICapPublisher _capPublisher;

        public UserController(IMediator mediator, ICapPublisher capPublisher)
        {
            _mediator = mediator;
            _capPublisher = capPublisher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand)
        {
            var result = await _mediator.Send(createUserCommand);

            // ======================= PUBLISHER ===============================

            if (result.Data != null)
            {
                await _capPublisher.PublishAsync<string>("createUser.transaction", result.Data.Id);
            }

            return ActionResultInstance(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return ActionResultInstance(await _mediator.Send(new GetUserByNameQuery(HttpContext.User.Identity.Name)));
        }

        [Authorize(Roles = "superadmin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUserRoles(CreateUserRolesCommand createUserRolesCommand)
        {
            return ActionResultInstance(await _mediator.Send(createUserRolesCommand));
        }
    }
}