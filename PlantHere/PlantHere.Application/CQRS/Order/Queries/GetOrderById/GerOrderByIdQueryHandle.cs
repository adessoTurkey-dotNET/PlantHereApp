namespace PlantHere.Application.CQRS.Order.Quries.GetOrderById
{
    public class GerOrderByIdQueryHandle : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GerOrderByIdQueryHandle(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<GetOrderByIdQueryResult>(await _orderRepository.GetOrderByIdWithChild(request.Id));
        }
    }

}
