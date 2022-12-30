namespace PlantHere.Application.CQRS.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {

        private readonly IOrderService _orderService;

        public DeleteOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetByIdAsync(request.Id);

            await _orderService.RemoveAsync(order);

            return Unit.Value;
        }
    }
}
