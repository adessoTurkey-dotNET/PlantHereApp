using MediatR;
using PlantHere.Domain.Aggregate.OrderAggregate.DomainEvents;

namespace PlantHere.Persistence.DomainEventHandlers
{
    public class OrderStartedDomainHandler : INotificationHandler<OrderStartedDomainEvent>
    {

        private readonly IEmailService _emailService;

        private readonly IBasketService _basketService;

        public OrderStartedDomainHandler(IEmailService emailService, IBasketService basketService)
        {
            _emailService = emailService;
            _basketService = basketService;
        }

        public async Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _emailService.Send("test.gmail.com", $"{notification.Order.GetTotalPrice}");

            await _basketService.RemoveBasket(notification.UserId);
        }
    }
}