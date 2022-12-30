namespace PlantHere.Application.CQRS.Basket.Queries.GetBasketByUserId
{
    public class GetBasketByUserIdQueryHandler : IRequestHandler<GetBasketByUserIdQuery, CustomResult<GetBasketByUserIdQueryResult>>
    {

        private readonly IBasketService _basketService;

        public GetBasketByUserIdQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<CustomResult<GetBasketByUserIdQueryResult>> Handle(GetBasketByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _basketService.GetBasketsByUserIdAsync(request.UserId);
        }
    }
}
