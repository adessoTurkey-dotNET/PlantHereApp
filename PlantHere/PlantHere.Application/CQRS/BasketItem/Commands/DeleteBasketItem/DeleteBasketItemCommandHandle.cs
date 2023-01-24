using PlantHere.Application.Interfaces;

namespace PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandle : IRequestHandler<DeleteBasketItemCommand, DeleteBasketItemCommandResult>, IRequestPreProcessor<DeleteBasketItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEnumerable<IValidator<DeleteBasketItemCommand>> _validators;

        public DeleteBasketItemCommandHandle(IUnitOfWork unitOfWork, IEnumerable<IValidator<DeleteBasketItemCommand>> validators)
        {
            _unitOfWork = unitOfWork;
            _validators = validators;
        }

        public async Task<DeleteBasketItemCommandResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            await  _unitOfWork.BasketRepository.DeleteBasketItem(request);
            await _unitOfWork.CommitAsync();
            return new DeleteBasketItemCommandResult();
        }

        public async Task Process(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<DeleteBasketItemCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;
        }
    }
}
