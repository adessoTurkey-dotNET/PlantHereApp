namespace PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem
{
    public class UpdateBasketItemCommandHandle : IRequestHandler<UpdateBasketItemCommand, CustomResult<UpdateBasketItemCommandResult>>, IRequestPreProcessor<UpdateBasketItemCommand>
    {
        private readonly IBasketService _basetService;

        private readonly IEnumerable<IValidator<UpdateBasketItemCommand>> _validators;

        public UpdateBasketItemCommandHandle(IBasketService basetService, IEnumerable<IValidator<UpdateBasketItemCommand>> validators)
        {
            _basetService = basetService;
            _validators = validators;
        }

        public async Task<CustomResult<UpdateBasketItemCommandResult>> Handle(UpdateBasketItemCommand request, CancellationToken cancellationToken)
        {
            return await _basetService.UpdateBasketItem(request);
        }

        public async Task Process(UpdateBasketItemCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<UpdateBasketItemCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;
        }
    }
}
