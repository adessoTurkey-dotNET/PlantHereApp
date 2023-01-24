using MediatR;
using PlantHere.Domain.Aggregate.OrderAggregate.DomainEvents;

namespace PlantHere.Persistence.DomainEventHandlers
{
    public class OrderStartedDomainHandler : INotificationHandler<OrderStartedDomainEvent>
    {

        private readonly IEmailRepository _emailService;

        private readonly IBasketRepository _basketRepository;

        public OrderStartedDomainHandler(IEmailRepository emailService, IBasketRepository basketRepository)
        {
            _emailService = emailService;
            _basketRepository = basketRepository;
        }

        public async Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _emailService.Send("test.gmail.com", $"{notification.Order.GetTotalPrice}");
            var basket = await _basketRepository.GetBasketByUserId(notification.UserId);
            await _basketRepository.RemoveAsync(basket);
        }
    }
}