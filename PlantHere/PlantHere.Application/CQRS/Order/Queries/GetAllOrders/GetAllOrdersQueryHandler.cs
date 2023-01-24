namespace PlantHere.Application.CQRS.Order.Quries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, ICollection<GetAllOrdersQueryResult>>
    {

        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ICollection<GetAllOrdersQueryResult>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<GetAllOrdersQueryResult>>(await _orderRepository.GetOrderWithChild());
        }
    }
}
