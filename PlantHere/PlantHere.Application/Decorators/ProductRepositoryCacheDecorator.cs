using Microsoft.Extensions.Caching.Memory;
using PlantHere.Domain.Aggregate.CategoryAggregate;



namespace PlantHere.Application.Decorators
{
    public class ProductRepositoryCacheDecorator : BaseProductRepositoryDecorator
    {
        private readonly IMemoryCache _memoryCache;

        private const string productCacheName = "products";

        public ProductRepositoryCacheDecorator(IProductRepository productRepository, IMemoryCache memoryCache) : base(productRepository)
        {
            _memoryCache = memoryCache;
        }

        public async override Task<List<Product>> GetAsync()
        {
            if (_memoryCache.TryGetValue(productCacheName, out List<Product> cacheProducts))
            {
                return cacheProducts;
            }

            await UpdateCache();

            return _memoryCache.Get<List<Product>>(productCacheName);
        }

        public override async Task<Product> AddAsync(Product entity)
        {
            await base.AddAsync(entity);
            await UpdateCache();
            return entity;
        }

        public async override Task RemoveAsync(Product entity)
        {
            await base.RemoveAsync(entity);

            await UpdateCache();
        }

        public async override Task UpdateAsync(Product entity)
        {
            await base.UpdateAsync(entity);

            await UpdateCache();
        }


        private async Task UpdateCache()
        {
            _memoryCache.Set(productCacheName, await base.GetAsync());
        }

    }
}
