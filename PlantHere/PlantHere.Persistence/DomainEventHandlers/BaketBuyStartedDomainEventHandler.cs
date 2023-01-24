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

        private readonly IPaymentRepository _paymentService;

        private readonly IOrderRepository _orderRepository;

        public BaketBuyStartedDomainEventHandler(IMapper mapper, IPaymentRepository paymentService, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _paymentService = paymentService;
            _orderRepository = orderRepository;
        }

        public async Task Handle(BaketBuyStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            if (_paymentService.ReceiverPayment(notification.CardTypeId, notification.CardNumber, notification.CardSecurityNumber, notification.CardHolderName))
            {
                if (notification.Basket.BasketItems.Count == 0) throw new NotFoundException($"Not Found Basket Items");
                var orderItems = _mapper.Map<List<ModelOrderItem>>(notification.Basket.BasketItems);
                var order = new ModelOrder(notification.Basket.UserId, notification.Address, orderItems);
                await _orderRepository.CreateOrder(order);
            }

        }
    }
}