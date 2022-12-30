namespace PlantHere.Application.CQRS.Order.Quries.GetOrderById
{
    public class GerOrderByIdQueryHandle : IRequestHandler<GetOrderByIdQuery, CustomResult<GetOrderByIdQueryResult>>
    {
        private readonly IOrderService _orderService;

        public GerOrderByIdQueryHandle(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<CustomResult<GetOrderByIdQueryResult>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return _orderService.GetOrderByIdWithChild(request.Id);
        }
    }

}
