namespace PlantHere.Application.CQRS.Order.Quries.GetOrderByUserId
{
    public class GetOrderByUserIdHandlerQuery : IRequestHandler<GetOrderByUserIdQuery, ICollection<GetOrderByUserIdQueryResult>>
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

        public GetOrderByUserIdHandlerQuery(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<GetOrderByUserIdQueryResult>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<GetOrderByUserIdQueryResult>>(await _orderRepository.GetOrderByUserId(request.userId));
        }
    }
}

