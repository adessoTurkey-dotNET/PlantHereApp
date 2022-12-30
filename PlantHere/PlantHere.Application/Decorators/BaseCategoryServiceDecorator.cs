using PlantHere.Domain.Aggregate.CategoryAggregate;
using System.Linq.Expressions;

namespace PlantHere.Application.Decorators
{
    public class BaseCategoryServiceDecorator : ICategoryService
    {

        private readonly ICategoryService _categoryService;

        public BaseCategoryServiceDecorator(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public virtual async Task<Category> AddAsync(Category entity)
        {
            await _categoryService.AddAsync(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<Category>> AddRangeAsync(IEnumerable<Category> entities)
        {
            await _categoryService.AddRangeAsync(entities);
            return entities;
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<Category, bool>> expression)
        {
            return await _categoryService.AnyAsync(expression);
        }

        public virtual async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryService.GetAllAsync();
        }

        public virtual async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryService.GetByIdAsync(id);
        }

        public virtual async Task RemoveAsync(Category entity)
        {
            await _categoryService.RemoveAsync(entity);
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<Category> entities)
        {
            await _categoryService.RemoveRangeAsync(entities);
        }

        public virtual async Task UpdateAsync(Category entity)
        {
            await _categoryService.UpdateAsync(entity);
        }

        public virtual IQueryable<Category> Where(Expression<Func<Category, bool>> expression)
        {
            return _categoryService.Where(expression);
        }
    }
}
