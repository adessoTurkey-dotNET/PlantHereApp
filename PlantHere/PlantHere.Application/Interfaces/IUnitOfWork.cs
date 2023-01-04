namespace PlantHere.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}
