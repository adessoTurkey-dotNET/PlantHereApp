namespace UdemyAuthServer.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommmitAsync();

        void Commit();
    }
}