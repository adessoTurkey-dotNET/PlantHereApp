using MediatR;
using PlantHere.Application.CQRS.Order.Commands.CreateOrder;
using PlantHere.Domain.Aggregate.BasketAggregate.DomainEvents;
using ModelOrder = PlantHere.Domain.Aggregate.OrderAggregate.Entities.Order;
using ModelOrderItem = PlantHere.Domain.Aggregate.OrderAggregate.Entities.OrderItem;

namespace PlantHere.Persistence.DomainEventHandlers
{
    public class BaketBuyStartedDomainEventHandler : INotificationHandler<BaketBuyStartedDomainEvent>
    {
        private readonly IMapper _mapper;

        private readonly IPaymentService _paymentService;

        private readonly IOrderService _orderService;

        public BaketBuyStartedDomainEventHandler(IMapper mapper, IPaymentService paymentService, IOrderService orderService)
        {
            _mapper = mapper;
            _paymentService = paymentService;
            _orderService = orderService;
        }

        public async Task Handle(BaketBuyStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            if (_paymentService.ReceiverPayment(notification.CardTypeId, notification.CardNumber, notification.CardSecurityNumber, notification.CardHolderName).Data)
            {//nurcan
                if (notification.Basket.BasketItems.Count == 0) throw new NotFoundException($"Not Found Basket Items");
                var orderItems = _mapper.Map<List<ModelOrderItem>>(notification.Basket.BasketItems);
                var order = new ModelOrder(notification.Basket.UserId, notification.Address, orderItems);
                await _orderService.CreateOrder(_mapper.Map<CreateOrderCommand>(order));
            }

        }
    }
}