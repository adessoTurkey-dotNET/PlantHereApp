using PlantHere.Application.CQRS.Order.Commands.CreateOrder;
using PlantHere.Application.CQRS.Order.Quries.GetAllOrders;
using PlantHere.Application.CQRS.Order.Quries.GetOrderById;
using PlantHere.Application.CQRS.Order.Quries.GetOrderByUserId;
using PlantHere.Domain.Aggregate.OrderAggregate.Entities;

namespace PlantHere.Application.Interfaces.Service
{
    public interface IOrderService : IService<Order>
    {
        Task<CustomResult<ICollection<GetAllOrdersQueryResult>>> GetOrderWithChild();

        Task<CustomResult<GetOrderByIdQueryResult>> GetOrderByIdWithChild(int id);

        Task<CustomResult<ICollection<GetOrderByUserIdQueryResult>>> GetOrderByUserId(string userId);

        Task<CustomResult<CreateOrderCommandResult>> CreateOrder(CreateOrderCommand order);
    }

}