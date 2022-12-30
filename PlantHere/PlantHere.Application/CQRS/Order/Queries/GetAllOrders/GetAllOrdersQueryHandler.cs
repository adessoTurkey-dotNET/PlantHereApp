namespace PlantHere.Application.CQRS.Order.Quries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, CustomResult<ICollection<GetAllOrdersQueryResult>>>
    {

        private readonly IOrderService _orderService;

        public GetAllOrdersQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<CustomResult<ICollection<GetAllOrdersQueryResult>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderService.GetOrderWithChild();
        }
    }
}
