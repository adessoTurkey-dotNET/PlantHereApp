using PlantHere.Application.Interfaces;
using ModelBasket = PlantHere.Domain.Aggregate.BasketAggregate.Entities.Basket;

namespace PlantHere.Application.CQRS.Basket.Commands.CreateBasket
{
    public class CreateBasketCommandHandle : IRequestHandler<CreateBasketCommand, CreateBasketCommandResult>, IRequestPreProcessor<CreateBasketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IValidator<CreateBasketCommand>> _validators;

        public CreateBasketCommandHandle(IUnitOfWork unitOfWork, IMapper mapper, IEnumerable<IValidator<CreateBasketCommand>> validators)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validators = validators;
        }

        public async Task<CreateBasketCommandResult> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BasketRepository.AddAsync(_mapper.Map<ModelBasket>(request));
            await _unitOfWork.CommitAsync();
            return new CreateBasketCommandResult();
        }

        public async Task Process(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<CreateBasketCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;

            var basket = await _unitOfWork.BasketRepository.GetBasketByUserId(request.UserId);

            if (basket != null) throw new ConflictException($"{typeof(ModelBasket).Name}({request.UserId}) Conflict");
        }
    }
}
