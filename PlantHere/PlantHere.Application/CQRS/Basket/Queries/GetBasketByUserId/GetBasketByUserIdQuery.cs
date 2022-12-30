namespace PlantHere.Application.CQRS.Basket.Queries.GetBasketByUserId
{
    public class GetBasketByUserIdQuery : IRequest<CustomResult<GetBasketByUserIdQueryResult>>
    {
        public string UserId { get; set; }

        public GetBasketByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
