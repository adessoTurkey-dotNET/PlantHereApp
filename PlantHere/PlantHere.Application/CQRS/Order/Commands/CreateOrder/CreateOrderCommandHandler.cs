using DotNetCore.CAP;
using PlantHere.Application.Interfaces;
using ModelOrder = PlantHere.Domain.Aggregate.OrderAggregate.Entities.Order;
using ModelOrderItem = PlantHere.Domain.Aggregate.OrderAggregate.Entities.OrderItem;


namespace PlantHere.Application.CQRS.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResult>, IRequestPreProcessor<CreateOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEnumerable<IValidator<CreateOrderCommand>> _validators;

        private readonly IMapper _mapper;

        private readonly ICapPublisher _capPublisher;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IEnumerable<IValidator<CreateOrderCommand>> validators, IMapper mapper, ICapPublisher capPublisher)
        {
            _unitOfWork = unitOfWork;
            _validators = validators;
            _mapper = mapper;
            _capPublisher = capPublisher;
        }

        public async Task<CreateOrderCommandResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            
            var order = _mapper.Map<ModelOrder>(request);
            order = order.AddOrder(_mapper.Map<List<ModelOrderItem>>(request.OrderItems));
            
            await _unitOfWork.OrderRepository.CreateOrder(order);
            
            await _unitOfWork.CommitAsync();
            
            await _capPublisher.PublishAsync<int>("createOrder.transaction", order.Id);
            
            return new CreateOrderCommandResult();
        }

        public async Task Process(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<CreateOrderCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;
        }

    }
}