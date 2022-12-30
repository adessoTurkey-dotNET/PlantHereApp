using Microsoft.EntityFrameworkCore;
using PlantHere.Domain.Aggregate.OrderAggregate.Entities;

namespace PlantHere.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Order> GetOrderByIdWithChild(int id)
        {
            var order = await _context.Orders.Include(x => x.Address).Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id);

            if (order == null) throw new NotFoundException($"{typeof(Order).Name}({id}) Not Found");

            return order;
        }

        public async Task<ICollection<Order>> GetOrderByUserId(string userId)
        {
            var order = await _context.Orders.Include(x => x.Address).Include(x => x.OrderItems).Where(x=> x.BuyerId == userId).ToListAsync();

            if (order == null) throw new NotFoundException($"{typeof(Order).Name}({userId}) Not Found");

            return order;
        }

        public async Task<ICollection<Order>> GetOrderWithChild()
        {
            return await _context.Orders.Include(x => x.Address).Include(x => x.OrderItems).ToListAsync();
        }


    }
}
