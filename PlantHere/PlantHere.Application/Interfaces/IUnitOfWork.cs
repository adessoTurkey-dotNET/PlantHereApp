namespace PlantHere.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetGenericRepository<T>() where T : class, new();

        IProductRepository ProductRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IBasketRepository BasketRepository { get; }

        IOrderRepository OrderRepository { get; }


        Task<bool> CommitAsync(CancellationToken cancellationToken = default);

    }
}
