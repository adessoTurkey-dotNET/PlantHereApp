using PlantHere.Application.CQRS.Address.Queries;
using PlantHere.Application.CQRS.OrderItem.Queries.GetAllOrderItems;

namespace PlantHere.Application.CQRS.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public AddressQueryResult? Address { get; set; }

        public string BuyerId { get; set; }

        public List<GetAllOrderItemsQueryResult> OrderItems { get; set; }

    }
}
