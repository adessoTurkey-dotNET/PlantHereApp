namespace PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem
{
    public class CreateBasketItemCommandHandle : IRequestHandler<CreateBasketItemCommand, CustomResult<CreateBasketItemCommandResult>>, IRequestPreProcessor<CreateBasketItemCommand>
    {
        private readonly IBasketService _basketService;

        private readonly IEnumerable<IValidator<CreateBasketItemCommand>> _validators;

        private readonly IMapper _mapper;

        public CreateBasketItemCommandHandle(IBasketService basketService, IEnumerable<IValidator<CreateBasketItemCommand>> validators, IMapper mapper)
        {
            _basketService = basketService;
            _validators = validators;
            _mapper = mapper;
        }

        public async Task<CustomResult<CreateBasketItemCommandResult>> Handle(CreateBasketItemCommand request, CancellationToken cancellationToken)
        {
            return await _basketService.CreateBasketItem(request);
        }

        public async Task Process(CreateBasketItemCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<CreateBasketItemCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;
        }
    }
}
