using PlantHere.Application.Interfaces;

namespace PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem
{
    public class UpdateBasketItemCommandHandle : IRequestHandler<UpdateBasketItemCommand, UpdateBasketItemCommandResult>, IRequestPreProcessor<UpdateBasketItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEnumerable<IValidator<UpdateBasketItemCommand>> _validators;

        public UpdateBasketItemCommandHandle(IUnitOfWork unitOfWork, IEnumerable<IValidator<UpdateBasketItemCommand>> validators)
        {
            _unitOfWork = unitOfWork;
            _validators = validators;
        }

        public async Task<UpdateBasketItemCommandResult> Handle(UpdateBasketItemCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BasketRepository.UpdateBasketItem(request);
            await _unitOfWork.CommitAsync();
            return new UpdateBasketItemCommandResult();
        }

        public async Task Process(UpdateBasketItemCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<UpdateBasketItemCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;
        }
    }
}
