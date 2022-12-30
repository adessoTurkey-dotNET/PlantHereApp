using PlantHere.Application.CQRS.Order.Commands.CreateOrder;
using PlantHere.Application.CQRS.Order.Quries.GetAllOrders;
using PlantHere.Application.CQRS.Order.Quries.GetOrderById;
using PlantHere.Application.CQRS.Order.Quries.GetOrderByUserId;
using PlantHere.Domain.Aggregate.OrderAggregate.Entities;

namespace PlantHere.Persistence.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IOrderRepository _orderReposity;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> repository, IUnitOfWork unitOfWork, IOrderRepository orderRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _orderReposity = orderRepository;
            _mapper = mapper;
        }

        public async Task<CustomResult<CreateOrderCommandResult>> CreateOrder(CreateOrderCommand createOrderCommand)
        {
            var order = _mapper.Map<Order>(createOrderCommand);
            order = order.AddOrder(_mapper.Map<List<OrderItem>>(createOrderCommand.OrderItems));
            await _orderReposity.AddAsync(order);
            await _unitOfWork.CommitAsync();
            return CustomResult<CreateOrderCommandResult>.Success(201, new CreateOrderCommandResult());

        }

        public async Task<CustomResult<GetOrderByIdQueryResult>> GetOrderByIdWithChild(int id)
        {
            return CustomResult<GetOrderByIdQueryResult>.Success(200, _mapper.Map<GetOrderByIdQueryResult>(await _orderReposity.GetOrderByIdWithChild(id)));
        }

        public async Task<CustomResult<ICollection<GetOrderByUserIdQueryResult>>> GetOrderByUserId(string userId)
        {
            var order = await _orderReposity.GetOrderByUserId(userId);
            return CustomResult<ICollection<GetOrderByUserIdQueryResult>>.Success(200, _mapper.Map<ICollection<GetOrderByUserIdQueryResult>>(order));
        }

        public async Task<CustomResult<ICollection<GetAllOrdersQueryResult>>> GetOrderWithChild()
        {
            var orders = await _orderReposity.GetOrderWithChild();

            return CustomResult<ICollection<GetAllOrdersQueryResult>>.Success(200, _mapper.Map<ICollection<GetAllOrdersQueryResult>>(orders));
        }
    }
}
