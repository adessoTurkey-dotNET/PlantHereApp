using DotNetCore.CAP;
using PlantHere.Application.Interfaces;
using ModelOrder = PlantHere.Domain.Aggregate.OrderAggregate.Entities.Order;
using ModelOrderItem = PlantHere.Domain.Aggregate.OrderAggregate.Entities.OrderItem;

namespace PlantHere.Application.CQRS.Basket.Commands.BuyBasket
{
    public class BuyBasketCommandHandler : IRequestHandler<BuyBasketCommand, BuyBasketCommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICapPublisher _capPublisher;

        private readonly IPaymentRepository _paymentRepository;

        private readonly IMapper _mapper;

        public BuyBasketCommandHandler(IUnitOfWork unitOfWork, ICapPublisher capPublisher, IPaymentRepository paymentRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _capPublisher = capPublisher;
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<BuyBasketCommandResult> Handle(BuyBasketCommand request, CancellationToken cancellationToken)
        {

            if (_paymentRepository.ReceiverPayment(request.Payment.CardTypeId, request.Payment.CardNumber, request.Payment.CardSecurityNumber, request.Payment.CardHolderName))
            {
                // Remove Basket
                var basket = await _unitOfWork.BasketRepository.BuyBasket(request);
                if (basket.BasketItems.Count == 0) throw new NotFoundException($"Not Found Basket Items");

                // Create Order
                var orderItems = _mapper.Map<List<ModelOrderItem>>(basket.BasketItems);
                var order = new ModelOrder(request.UserId, request.Address, orderItems);
                
                order = order.AddOrder(orderItems);
                
                await _unitOfWork.OrderRepository.CreateOrder(order);

                // Commit
                await _unitOfWork.CommitAsync();
                
                // Rabbit MQ Publish
                await _capPublisher.PublishAsync<string>("buyBasket.transaction", request.UserId);
            }


            return new BuyBasketCommandResult();
        }
    }
}
