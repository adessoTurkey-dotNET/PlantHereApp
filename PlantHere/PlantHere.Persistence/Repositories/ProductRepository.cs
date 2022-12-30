using Microsoft.EntityFrameworkCore;
using PlantHere.Domain.Aggregate.CategoryAggregate;
using PlantHere.Domain.Aggregate.OrderAggregate.Entities;

namespace PlantHere.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public  async Task<Product> GetProductByUniqueIdWithImages(string uniqueId)
        {
            var product = await _context.Products.Include(x => x.Images).FirstOrDefaultAsync(x => x.UniqueId == uniqueId);
            if (product == null) throw new NotFoundException($"{typeof(Product).Name}({uniqueId}) Not Found");
            return product;
        }

        public async Task<ICollection<Product>> GetProductsByPage(int page, int pageSize)
        {
            return await _context.Products.Include(x=> x.Images).OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
