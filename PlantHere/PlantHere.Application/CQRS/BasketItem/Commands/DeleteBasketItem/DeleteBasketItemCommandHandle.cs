namespace PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandle : IRequestHandler<DeleteBasketItemCommand, CustomResult<DeleteBasketItemCommandResult>>, IRequestPreProcessor<DeleteBasketItemCommand>
    {
        private readonly IBasketService _basketService;

        private readonly IEnumerable<IValidator<DeleteBasketItemCommand>> _validators;

        public DeleteBasketItemCommandHandle(IBasketService basketService, IEnumerable<IValidator<DeleteBasketItemCommand>> validators)
        {
            _basketService = basketService;
            _validators = validators;
        }

        public async Task<CustomResult<DeleteBasketItemCommandResult>> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            return await _basketService.DeleteBasketItem(request);
        }

        public async Task Process(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<DeleteBasketItemCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;
        }
    }
}
