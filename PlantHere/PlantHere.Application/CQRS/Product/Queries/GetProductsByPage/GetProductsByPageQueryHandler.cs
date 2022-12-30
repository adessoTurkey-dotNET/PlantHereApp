namespace PlantHere.Application.CQRS.Product.Queries.GetProductsByPage
{
    public class GetProductsByPageQueryHandler : IRequestHandler<GetProductsByPageQuery, CustomResult<ICollection<GetProductsByPageQueryResult>>>
    {
        private readonly IProductService _productService;

        public GetProductsByPageQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public Task<CustomResult<ICollection<GetProductsByPageQueryResult>>> Handle(GetProductsByPageQuery request, CancellationToken cancellationToken)
        {
            return _productService.GetProductsByPage(request);
        }
    }
}
