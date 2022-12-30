namespace PlantHere.Application.CQRS.Product.Queries.GetProductByUniqueId
{
    public class GetProductByUniqueIdQueryHandler : IRequestHandler<GetProductByUniqueIdQuery, CustomResult<GetProductByUniqueIdQueryResult>>
    {

        private readonly IProductService _productService;

        private readonly IMapper _mapper;

        public GetProductByUniqueIdQueryHandler(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<CustomResult<GetProductByUniqueIdQueryResult>> Handle(GetProductByUniqueIdQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductByUniqueId(request);
        }
    }
}
