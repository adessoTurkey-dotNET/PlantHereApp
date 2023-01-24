using Microsoft.Extensions.Logging;
using PlantHere.Domain.Aggregate.CategoryAggregate;

namespace PlantHere.Application.Decorators
{
    public class ProductRepositoryLoggingDecorator : BaseProductRepositoryDecorator
    {

        private readonly ILogger<ProductRepositoryLoggingDecorator> _logger;

        public ProductRepositoryLoggingDecorator(IProductRepository productRepository,
            ILogger<ProductRepositoryLoggingDecorator> logger) : base(productRepository)
        {
            _logger = logger;
        }

        public async override Task<List<Product>> GetAsync()
        {
            _logger.LogInformation("GetAllAsync method executed...");
            return await base.GetAsync();
        }

        public override async Task<Product> AddAsync(Product entity)
        {
            _logger.LogInformation("AddAsync method executed...");
            await base.AddAsync(entity);
            return entity;
        }

        public async override Task RemoveAsync(Product entity)
        {
            _logger.LogInformation("Remove method executed...");
            await base.RemoveAsync(entity);
        }

        public async override Task UpdateAsync(Product entity)
        {
            _logger.LogInformation("Update method executed...");
            await base.UpdateAsync(entity);

        }

    }
}
