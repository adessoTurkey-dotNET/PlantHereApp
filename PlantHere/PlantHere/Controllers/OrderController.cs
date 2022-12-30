using PlantHere.Application.CQRS.Order.Commands.CreateOrder;
using PlantHere.Application.CQRS.Order.Commands.UpdateOrder;
using PlantHere.Application.CQRS.Order.Quries.GetAllOrders;
using PlantHere.Application.CQRS.Order.Quries.GetOrderById;
using PlantHere.Application.CQRS.Order.Quries.GetOrderByUserId;
using PlantHere.Application.CQRS.Product.Commands.DeleteProduct;

namespace PlantHere.WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrderController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Authorize(Roles = "superadmin")]
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return CreateActionResult(orders);
        }

        [Authorize(Roles = "superadmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderId(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));
            return CreateActionResult(order);
        }

        [Authorize(Roles = "customer,superadmin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrderByUserId()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            return CreateActionResult(await _mediator.Send(new GetOrderByUserIdQuery(userId)));
        }

        [Authorize(Roles = "superadmin")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return CreateActionResult(CustomResult<GetOrderByIdQueryResult>.Success(204));
        }

        [Authorize(Roles = "superadmin")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            return CreateActionResult(await _mediator.Send(command));
        }

        [Authorize(Roles = "superadmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return CreateActionResult(CustomResult<DeleteProductCommand>.Success(204));
        }

    }
}
