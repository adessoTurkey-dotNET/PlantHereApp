using AuthServer.Application.CQRS.Authentication.Commands.RevokeRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AuthServer.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByUser(CreateTokenByUserCommand createTokenByUserQuery)
        {
            var result = await _mediator.Send(createTokenByUserQuery);

            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RevokeRefreshTokenCommand revokeRefreshTokenCommand)
        {
            var result = await _mediator.Send(revokeRefreshTokenCommand);

            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(CreateTokenByRefreshTokenCommand createTokenByRefreshTokenCommand)

        {
            var result = await _mediator.Send(createTokenByRefreshTokenCommand);

            return ActionResultInstance(result);
        }
    }
}