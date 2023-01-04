using PlantHere.Application.CQRS.Product.Queries.GetProductByUniqueId;
using PlantHere.Application.CQRS.Product.Queries.GetProductsByPage;
using PlantHere.Domain.Aggregate.CategoryAggregate;

namespace PlantHere.Application.Interfaces.Service
{
    public interface IProductService : IService<Product>
    {
        public Task<IEnumerable<GetProductsByPageQueryResult>> GetProductsByPage(GetProductsByPageQuery getproductsByPageQuery);

        public Task<CustomResult<GetProductByUniqueIdQueryResult>> GetProductByUniqueId(GetProductByUniqueIdQuery getProductByUniqueIdQuery);

    }
}
