using PlantHere.Application.Interfaces.Repositories;

namespace PlantHere.Infrastructure
{
    public class EmailRepository : IEmailRepository
    {
        public async Task<bool> Send(string to, string message)
        {
            return true;
        }
    }
}
