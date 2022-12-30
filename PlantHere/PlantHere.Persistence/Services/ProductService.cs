using PlantHere.Application.CQRS.Product.Queries.GetProductByUniqueId;
using PlantHere.Application.CQRS.Product.Queries.GetProductsByPage;
using PlantHere.Domain.Aggregate.CategoryAggregate;
using PlantHere.Persistence.Services;

namespace PlantHere.Application.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResult<GetProductByUniqueIdQueryResult>> GetProductByUniqueId(GetProductByUniqueIdQuery getProductByUniqueIdQuery)
        {
            var product = await _productRepository.GetProductByUniqueIdWithImages(getProductByUniqueIdQuery.UniqueId);

            return CustomResult<GetProductByUniqueIdQueryResult>.Success(200, _mapper.Map<GetProductByUniqueIdQueryResult>(product));
        }

        public async Task<CustomResult<ICollection<GetProductsByPageQueryResult>>> GetProductsByPage(GetProductsByPageQuery getproductsByPageQuery)
        {
            var products = await _productRepository.GetProductsByPage(getproductsByPageQuery.Page, getproductsByPageQuery.PageSize);
            
            var getProductsByPageQueryResult = _mapper.Map<ICollection<GetProductsByPageQueryResult>>(products);

            if (products.Count() == 0)
            {
                return CustomResult<ICollection<GetProductsByPageQueryResult>>.Success(404, getProductsByPageQueryResult);
            }
            
            return CustomResult<ICollection<GetProductsByPageQueryResult>>.Success(200, getProductsByPageQueryResult);
        }
    }
}
