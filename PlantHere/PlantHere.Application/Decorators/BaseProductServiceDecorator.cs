using PlantHere.Application.CQRS.Product.Queries.GetProductByUniqueId;
using PlantHere.Application.CQRS.Product.Queries.GetProductsByPage;
using PlantHere.Domain.Aggregate.CategoryAggregate;
using System.Linq.Expressions;

namespace PlantHere.Application.Decorators
{
    public class BaseProductServiceDecorator : IProductService
    {
        public readonly IProductService _productService;

        public BaseProductServiceDecorator(IProductService productService)
        {
            _productService = productService;
        }

        public virtual async Task<Product> AddAsync(Product entity)
        {
            await _productService.AddAsync(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            await _productService.AddRangeAsync(entities);
            return entities;
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            return await _productService.AnyAsync(expression);
        }

        public virtual async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productService.GetAllAsync();
        }

        public virtual async Task<Product> GetByIdAsync(int id)
        {
            return await _productService.GetByIdAsync(id);
        }

        public async Task<CustomResult<GetProductByUniqueIdQueryResult>> GetProductByUniqueId(GetProductByUniqueIdQuery getProductByUniqueIdQuery)
        {
            return await _productService.GetProductByUniqueId(getProductByUniqueIdQuery);
        }

        public async Task<IEnumerable<GetProductsByPageQueryResult>> GetProductsByPage(GetProductsByPageQuery getproductsByPageQuery)
        {
            return await _productService.GetProductsByPage(getproductsByPageQuery);
        }

        public virtual async Task RemoveAsync(Product entity)
        {
            await _productService.RemoveAsync(entity);
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
            await _productService.RemoveRangeAsync(entities);
        }

        public virtual async Task UpdateAsync(Product entity)
        {
            await _productService.UpdateAsync(entity);
        }

        public virtual IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _productService.Where(expression);
        }
    }
}
