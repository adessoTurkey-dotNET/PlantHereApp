using PlantHere.Domain.Aggregate.OrderAggregate.Entities;

namespace PlantHere.Application.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<ICollection<Order>> GetOrderWithChild();

        Task<Order> GetOrderByIdWithChild(int id);

        Task<ICollection<Order>> GetOrderByUserId(string userId);
    }
}
