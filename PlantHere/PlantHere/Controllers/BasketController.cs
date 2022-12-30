using PlantHere.Application.CQRS.Basket.Commands.BuyBasket;
using PlantHere.Application.CQRS.Basket.Commands.CreateBasket;
using PlantHere.Application.CQRS.Basket.Queries.GetBasketByUserId;


namespace PlantHere.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "customer,superadmin")]
        [HttpGet]
        public async Task<IActionResult> GetBasketByUserId()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var baskests = await _mediator.Send(new GetBasketByUserIdQuery(userId));
            return CreateActionResult(baskests);
        }

        [Authorize(Roles = "customer,superadmin")]
        [HttpPost]
        public async Task<IActionResult> CreateBasket()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var baskests = await _mediator.Send(new CreateBasketCommand(userId));
            return CreateActionResult(baskests);
        }

        [Authorize(Roles = "customer,superadmin")]
        [HttpPost("[Action]")]
        public async Task<IActionResult> BuyBasket(BuyBasketCommand command)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            command.UserId = userId;
            await _mediator.Send(command);
            return CreateActionResult(CustomResult<BuyBasketCommandResult>.Success(200));
        }
    }
}
