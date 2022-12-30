using Microsoft.Extensions.Caching.Memory;
using PlantHere.Domain.Aggregate.CategoryAggregate;



namespace PlantHere.Application.Decorators
{
    public class ProductServiceCacheDecorator : BaseProductServiceDecorator
    {
        private readonly IMemoryCache _memoryCache;

        private const string productCacheName = "products";

        public ProductServiceCacheDecorator(IProductService productService, IMemoryCache memoryCache) : base(productService)
        {
            _memoryCache = memoryCache;
        }

        public async override Task<IEnumerable<Product>> GetAllAsync()
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
            _memoryCache.Set(productCacheName, await base.GetAllAsync());
        }

    }
}
