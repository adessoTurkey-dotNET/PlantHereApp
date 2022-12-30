namespace PlantHere.Application.CQRS.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CustomResult<CreateOrderCommandResult>>, IRequestPreProcessor<CreateOrderCommand>
    {
        private readonly IOrderService _orderService;

        private readonly IEnumerable<IValidator<CreateOrderCommand>> _validators;

        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderService orderService, IEnumerable<IValidator<CreateOrderCommand>> validators, IMapper mapper)
        {
            _orderService = orderService;
            _validators = validators;
            _mapper = mapper;
        }

        public async Task<CustomResult<CreateOrderCommandResult>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderService.CreateOrder(request);
            return order;
        }

        public async Task Process(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<CreateOrderCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;
        }

    }
}