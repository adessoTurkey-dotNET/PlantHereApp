using PlantHere.Persistence.Services;
using ModelCategory = PlantHere.Domain.Aggregate.CategoryAggregate.Category;

namespace PlantHere.Application.CQRS.Decorators
{
    public class CategoryService : Service<ModelCategory>, ICategoryService
    {
        public CategoryService(IRepository<ModelCategory> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
