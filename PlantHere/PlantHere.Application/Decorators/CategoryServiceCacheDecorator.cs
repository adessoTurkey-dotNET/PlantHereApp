using Microsoft.Extensions.Caching.Memory;
using PlantHere.Domain.Aggregate.CategoryAggregate;

namespace PlantHere.Application.Decorators
{
    public class CategoryServiceCacheDecorator : BaseCategoryServiceDecorator
    {
        private readonly IMemoryCache _memoryCache;

        private const string categoriesCacheName = "categoties";

        public CategoryServiceCacheDecorator(ICategoryService categoryService, IMemoryCache memoryCache) : base(categoryService)
        {
            _memoryCache = memoryCache;
        }

        public async override Task<IEnumerable<Category>> GetAllAsync()
        {
            if (_memoryCache.TryGetValue(categoriesCacheName, out List<Category> cacheCategories))
            {
                return cacheCategories;
            }

            await UpdateCache();

            return _memoryCache.Get<List<Category>>(categoriesCacheName);
        }

        public override async Task<Category> AddAsync(Category entity)
        {
            await base.AddAsync(entity);
            await UpdateCache();
            return entity;
        }

        public async override Task RemoveAsync(Category entity)
        {
            await base.RemoveAsync(entity);

            await UpdateCache();
        }

        public async override Task UpdateAsync(Category entity)
        {
            await base.UpdateAsync(entity);

            await UpdateCache();
        }

        private async Task UpdateCache()
        {
            _memoryCache.Set(categoriesCacheName, await base.GetAllAsync());
        }


    }
}
