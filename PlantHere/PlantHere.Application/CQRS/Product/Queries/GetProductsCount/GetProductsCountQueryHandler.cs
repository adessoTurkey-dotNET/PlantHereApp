namespace PlantHere.Application.CQRS.Product.Queries.GetProductsCount
{
    public class GetProductsCountQueryHandler : IRequestHandler<GetProductsCountQuery, CustomResult<GetProductsCountQueryResult>>
    {
        private readonly IProductService _productService;

        public GetProductsCountQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<CustomResult<GetProductsCountQueryResult>> Handle(GetProductsCountQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllAsync();
            return CustomResult<GetProductsCountQueryResult>.Success(200, new GetProductsCountQueryResult(products.Count()));
        }
    }
}
