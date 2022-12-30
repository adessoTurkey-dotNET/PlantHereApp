namespace PlantHere.Application.Interfaces.Service
{
    public interface IEmailService
    {
        Task<CustomResult<bool>> Send(string to, string message);
    }
}
