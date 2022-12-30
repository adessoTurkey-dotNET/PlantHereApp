
using ModelBasket = PlantHere.Domain.Aggregate.BasketAggregate.Entities.Basket;

namespace PlantHere.Application.CQRS.Basket.Commands.CreateBasket
{
    public class CreateBasketCommandHandle : IRequestHandler<CreateBasketCommand, CustomResult<CreateBasketCommandResult>>, IRequestPreProcessor<CreateBasketCommand>
    {
        private readonly IBasketService _basketService;
        private readonly IBasketRepository _basketRepository;

        private readonly IMapper _mapper;

        private readonly IEnumerable<IValidator<CreateBasketCommand>> _validators;

        public CreateBasketCommandHandle(IBasketService basketService, IBasketRepository basketRepository, IMapper mapper, IEnumerable<IValidator<CreateBasketCommand>> validators)
        {
            _basketService = basketService;
            _basketRepository = basketRepository;
            _mapper = mapper;
            _validators = validators;
        }

        public async Task<CustomResult<CreateBasketCommandResult>> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {

            await _basketService.AddAsync(_mapper.Map<ModelBasket>(request));
            return CustomResult<CreateBasketCommandResult>.Success(204, new CreateBasketCommandResult());
        }

        public async Task Process(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<CreateBasketCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;

            var basket = await _basketRepository.GetBasketByUserId(request.UserId);

            if (basket != null) throw new ConflictException($"{typeof(ModelBasket).Name}({request.UserId}) Conflict");
        }
    }
}
