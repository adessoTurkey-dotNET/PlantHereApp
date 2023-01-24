using PlantHere.Application.Interfaces;
using ModelAddress = PlantHere.Domain.Aggregate.OrderAggregate.ValueObjects.Address;
using ModelOrderItem = PlantHere.Domain.Aggregate.OrderAggregate.Entities.OrderItem;

namespace PlantHere.Application.CQRS.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderCommandResult>, IRequestPreProcessor<UpdateOrderCommand>
    {

        private readonly IEnumerable<IValidator<UpdateOrderCommand>> _validators;

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderCommandHandler(IEnumerable<IValidator<UpdateOrderCommand>> validators, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _validators = validators;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateOrderCommandResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderByIdWithChild(request.Id);
            order.UpdateOrder(request.BuyerId, _mapper.Map<ModelAddress>(request.Address), _mapper.Map<List<ModelOrderItem>>(request.OrderItems));
            await _unitOfWork.OrderRepository.UpdateAsync(order);
            await _unitOfWork.CommitAsync();
            return new UpdateOrderCommandResult();
        }

        public async Task Process(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<UpdateOrderCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;
        }
    }
}
