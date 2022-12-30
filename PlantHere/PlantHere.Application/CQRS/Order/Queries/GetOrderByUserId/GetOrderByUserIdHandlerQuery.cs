namespace PlantHere.Application.CQRS.Order.Quries.GetOrderByUserId
{
    public class GetOrderByUserIdHandlerQuery : IRequestHandler<GetOrderByUserIdQuery, CustomResult<ICollection<GetOrderByUserIdQueryResult>>>
    {
        private readonly IOrderService _orderService;

        public GetOrderByUserIdHandlerQuery(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<CustomResult<ICollection<GetOrderByUserIdQueryResult>>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderService.GetOrderByUserId(request.userId);
        }
    }
}

