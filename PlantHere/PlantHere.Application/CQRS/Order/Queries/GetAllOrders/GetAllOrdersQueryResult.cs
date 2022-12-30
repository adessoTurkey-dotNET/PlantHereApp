using PlantHere.Application.CQRS.Address.Queries;
using PlantHere.Application.CQRS.OrderItem.Queries.GetAllOrderItems;

namespace PlantHere.Application.CQRS.Order.Quries.GetAllOrders
{
    public class GetAllOrdersQueryResult
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public AddressQueryResult Address { get; set; }

        public string BuyerId { get; set; }

        public List<GetAllOrderItemsQueryResult> OrderItems { get; set; }

    }
}
