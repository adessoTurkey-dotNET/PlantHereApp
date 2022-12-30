

using PlantHere.Domain.Aggregate.CategoryAggregate;

namespace PlantHere.Application.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<ICollection<Product>> GetProductsByPage(int Page, int PageSize);

        public Task<Product> GetProductByUniqueIdWithImages(string uniqueId);
    }
}
