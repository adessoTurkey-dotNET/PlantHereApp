using PlantHere.Persistence.Repositories;
using System.Data.Entity;

namespace PlantHere.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IBasketRepository _basketRepository;
        private IOrderRepository _orderRepository;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetGenericRepository<T>() where T : class, new()
        {
            return new Repository<T>(_context);
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public IProductRepository ProductRepository =>
            _productRepository ??= new ProductRepository(_context);

        public ICategoryRepository CategoryRepository =>
            _categoryRepository ??= new CategoryRepository(_context);


        public IOrderRepository OrderRepository =>
            _orderRepository ??= new OrderRepository(_context);

        public IBasketRepository BasketRepository =>
            _basketRepository ??= new BasketRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
