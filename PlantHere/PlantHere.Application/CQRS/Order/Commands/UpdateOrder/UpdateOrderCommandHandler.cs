using ModelAddress = PlantHere.Domain.Aggregate.OrderAggregate.ValueObjects.Address;
using ModelOrderItem = PlantHere.Domain.Aggregate.OrderAggregate.Entities.OrderItem;

namespace PlantHere.Application.CQRS.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>, IRequestPreProcessor<UpdateOrderCommand>
    {
        private readonly IOrderService _orderService;

        private readonly IEnumerable<IValidator<UpdateOrderCommand>> _validators;

        private readonly IMapper _mapper;

        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderService orderService, IEnumerable<IValidator<UpdateOrderCommand>> validators, IMapper mapper, IOrderRepository orderRepository)
        {
            _orderService = orderService;
            _validators = validators;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdWithChild(request.Id);
            order.UpdateOrder(request.BuyerId, _mapper.Map<ModelAddress>(request.Address), _mapper.Map<List<ModelOrderItem>>(request.OrderItems));
            await _orderService.UpdateAsync(order);
            return Unit.Value;
        }

        public async Task Process(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<UpdateOrderCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;
        }
    }
}
