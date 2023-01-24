using PlantHere.Application.Interfaces;

namespace PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem
{
    public class CreateBasketItemCommandHandle : IRequestHandler<CreateBasketItemCommand, CreateBasketItemCommandResult>, IRequestPreProcessor<CreateBasketItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEnumerable<IValidator<CreateBasketItemCommand>> _validators;

        public CreateBasketItemCommandHandle(IUnitOfWork unitOfWork, IEnumerable<IValidator<CreateBasketItemCommand>> validators)
        {
            _unitOfWork = unitOfWork;
            _validators = validators;
        }

        public async Task<CreateBasketItemCommandResult> Handle(CreateBasketItemCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BasketRepository.CreateBasketItem(request);
            await _unitOfWork.CommitAsync();
            return new CreateBasketItemCommandResult();
        }

        public async Task Process(CreateBasketItemCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<CreateBasketItemCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;
        }
    }
}
