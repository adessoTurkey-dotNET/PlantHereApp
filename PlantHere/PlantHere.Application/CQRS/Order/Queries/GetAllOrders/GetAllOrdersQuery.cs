namespace PlantHere.Application.CQRS.Order.Quries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<CustomResult<ICollection<GetAllOrdersQueryResult>>>
    {
    }
}
