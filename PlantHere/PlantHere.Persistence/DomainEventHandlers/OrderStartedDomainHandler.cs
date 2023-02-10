using MediatR;
using Microsoft.EntityFrameworkCore;
using PlantHere.Domain.Aggregate.OrderAggregate.DomainEvents;
using ModelBasket = PlantHere.Domain.Aggregate.BasketAggregate.Entities.Basket;

namespace PlantHere.Persistence.DomainEventHandlers
{
    public class OrderStartedDomainHandler : INotificationHandler<OrderStartedDomainEvent>
    {

        private readonly IEmailRepository _emailService;

        private readonly IUnitOfWork _unitOfWork;

        public OrderStartedDomainHandler(IEmailRepository emailService, IUnitOfWork unitOfWork)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _emailService.Send("test.gmail.com", $"{notification.Order.GetTotalPrice}");
            var basket = await _unitOfWork.GetGenericRepository<ModelBasket>().Where(x => x.UserId == notification.UserId).FirstOrDefaultAsync();
            await _unitOfWork.GetGenericRepository<ModelBasket>().RemoveAsync(basket);
        }
    }
}