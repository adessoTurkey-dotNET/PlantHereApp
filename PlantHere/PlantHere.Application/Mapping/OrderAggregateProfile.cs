using PlantHere.Application.CQRS.Address.Queries;
using PlantHere.Application.CQRS.Order.Commands.CreateOrder;
using PlantHere.Application.CQRS.Order.Quries.GetAllOrders;
using PlantHere.Application.CQRS.Order.Quries.GetOrderById;
using PlantHere.Application.CQRS.Order.Quries.GetOrderByUserId;
using PlantHere.Application.CQRS.OrderItem.Queries.GetAllOrderItems;
using PlantHere.Domain.Aggregate.OrderAggregate.Entities;
using PlantHere.Domain.Aggregate.OrderAggregate.ValueObjects;

namespace PlantHere.Application.Mapping
{
    public class OrderAggregateProfile : Profile
    {
        public OrderAggregateProfile()
        {

            CreateMap<Order, CreateOrderCommandResult>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, GetOrderByIdQueryResult>().ReverseMap();
            CreateMap<Order, GetAllOrdersQueryResult>().ReverseMap();
            CreateMap<Order, GetOrderByUserIdQueryResult>().ReverseMap();
            CreateMap<OrderItem, GetAllOrderItemsQueryResult>().ReverseMap();
            CreateMap<Address, AddressQueryResult>().ReverseMap();
        }
    }
}
