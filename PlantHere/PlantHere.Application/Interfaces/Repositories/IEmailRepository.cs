namespace PlantHere.Application.Interfaces.Repositories
{
    public interface IEmailRepository
    {
        Task<bool> Send(string to, string message);
    }
}
