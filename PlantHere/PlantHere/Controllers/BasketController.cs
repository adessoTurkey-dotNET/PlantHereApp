using DotNetCore.CAP;
using PlantHere.Application.CQRS.Basket.Commands.BuyBasket;
using PlantHere.Application.CQRS.Basket.Commands.CreateBasket;
using PlantHere.Application.CQRS.Basket.Queries.GetBasketByUserId;
using System.Text.Json;

namespace PlantHere.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketController : CustomBaseController
    {
        private readonly IMediator _mediator;

        private readonly ICapPublisher _capPublisher;

        public BasketController(IMediator mediator, ICapPublisher capPublisher)
        {
            _mediator = mediator;
            _capPublisher = capPublisher;
        }

        [Authorize(Roles = "customer,superadmin")]
        [HttpGet]
        public async Task<IActionResult> GetBasketByUserId()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var baskests = await _mediator.Send(new GetBasketByUserIdQuery(userId));
            return CreateActionResult(baskests);
        }

        // =============  Cap Subscribe ===================

        [CapSubscribe("buyBasket.transaction")]
        [CapSubscribe("createUser.transaction")]
        [NonAction]
        [HttpPost]
        public async Task<IActionResult> CreateBasket(string  userId)
        {
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

            // ======================= PUBLISHER ===============================

            await _capPublisher.PublishAsync<string>("buyBasket.transaction", userId);

            return CreateActionResult(CustomResult<BuyBasketCommandResult>.Success(200));
        }
    }
}
