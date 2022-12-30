using PlantHere.Domain.Aggregate.CategoryAggregate;

namespace PlantHere.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
