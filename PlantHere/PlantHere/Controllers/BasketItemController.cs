using PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem;

namespace PlantHere.WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class BasketItemController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public BasketItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "superadmin,customer")]
        [HttpPost]
        public async Task<IActionResult> CreateBasketItem(CreateBasketItemCommand command)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            command.UserId = userId;
            await _mediator.Send(command);
            return CreateActionResult(CustomResult<CreateBasketItemCommand>.Success(204));
        }

        [Authorize(Roles = "superadmin,customer")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBasketItem(DeleteBasketItemCommand command)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            command.UserId = userId;
            return CreateActionResult(await _mediator.Send(command));
        }

        [Authorize(Roles = "superadmin,customer")]
        [HttpPut]
        public async Task<IActionResult> UpdateBasketItem(UpdateBasketItemCommand command)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            command.UserId = userId;
            return CreateActionResult(await _mediator.Send(command));
        }
    }
}
