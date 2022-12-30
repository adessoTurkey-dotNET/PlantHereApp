using Microsoft.Extensions.Logging;
using PlantHere.Domain.Aggregate.CategoryAggregate;

namespace PlantHere.Application.Decorators
{
    public class ProductServiceLoggingDecorator : BaseProductServiceDecorator
    {

        private readonly ILogger<ProductServiceLoggingDecorator> _logger;

        public ProductServiceLoggingDecorator(IProductService productService,
            ILogger<ProductServiceLoggingDecorator> logger) : base(productService)
        {
            _logger = logger;
        }

        public async override Task<IEnumerable<Product>> GetAllAsync()
        {
            _logger.LogInformation("GetAllAsync method executed...");
            return await base.GetAllAsync();
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
