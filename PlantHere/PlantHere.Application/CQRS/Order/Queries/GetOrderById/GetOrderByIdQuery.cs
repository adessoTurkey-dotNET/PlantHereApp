namespace PlantHere.Application.CQRS.Order.Quries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<CustomResult<GetOrderByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
