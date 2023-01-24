namespace PlantHere.Application.CQRS.Product.Queries.GetProductsCount
{
    public class GetProductsCountQueryHandler : IRequestHandler<GetProductsCountQuery, GetProductsCountQueryResult>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsCountQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductsCountQueryResult> Handle(GetProductsCountQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAsync();
            return new GetProductsCountQueryResult(products.Count());
        }
    }
}
