namespace PlantHere.Application.CQRS.Order.Quries.GetOrderByUserId
{
    public class GetOrderByUserIdQuery : IRequest<CustomResult<ICollection<GetOrderByUserIdQueryResult>>>
    {
        public string userId { get; set; }

        public GetOrderByUserIdQuery(string userId)
        {
            this.userId = userId;
        }
    }
}
