using PlantHere.Domain.Aggregate.CategoryAggregate;
using System.Linq.Expressions;

namespace PlantHere.Application.Decorators
{
    public class BaseProductRepositoryDecorator : IProductRepository
    {
        public readonly IProductRepository _productRepository;

        public BaseProductRepositoryDecorator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public virtual async Task AddAsync(Product entity)
        {
            await _productRepository.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<Product> entities)
        {
            await _productRepository.AddRangeAsync(entities);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            return await _productRepository.AnyAsync(expression);
        }

        public virtual IQueryable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public virtual Task<List<Product>> GetAsync()
        {
            return _productRepository.GetAsync();
        }

        public virtual async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public virtual Task<Product> GetProductByUniqueIdWithImages(string uniqueId)
        {
            return _productRepository.GetProductByUniqueIdWithImages(uniqueId);
        }

        public virtual Task<ICollection<Product>> GetProductsByPage(int Page, int PageSize)
        {
            return _productRepository.GetProductsByPage(Page, PageSize);
        }

        public virtual void Remove(Product entity)
        {
            _productRepository.Remove(entity);
        }

        public virtual async Task RemoveAsync(Product entity)
        {
            await _productRepository.RemoveAsync(entity);
        }

        public virtual void RemoveRange(IEnumerable<Product> entities)
        {
            _productRepository.RemoveRange(entities);
        }

        public virtual void Update(Product entity)
        {
            _productRepository.Update(entity);
        }

        public virtual async Task UpdateAsync(Product entity)
        {
            await _productRepository.UpdateAsync(entity);
        }

        public virtual IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _productRepository.Where(expression);
        }
    }
}
