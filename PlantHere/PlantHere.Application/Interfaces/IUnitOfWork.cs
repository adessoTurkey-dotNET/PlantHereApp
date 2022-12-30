namespace PlantHere.Application.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}
