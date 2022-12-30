namespace PlantHere.Application.CQRS.Basket.Commands.BuyBasket
{
    public class BuyBasketCommandHandler : IRequestHandler<BuyBasketCommand, CustomResult<BuyBasketCommandResult>>
    {
        private readonly IBasketService _basketService;

        public BuyBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<CustomResult<BuyBasketCommandResult>> Handle(BuyBasketCommand request, CancellationToken cancellationToken)
        {
            return await _basketService.BuyBasket(request);
        }
    }
}
