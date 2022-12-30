using PlantHere.Application.CQRS.Product.Queries.GetAllProducts;

namespace PlantHere.Application.CQRS.Product.Queries.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<GetAllProductsQueryResult>>
    {
        private readonly IProductService _productService;

        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<IEnumerable<GetAllProductsQueryResult>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAllProductsQueryResult>>(products);
        }
    }
}
