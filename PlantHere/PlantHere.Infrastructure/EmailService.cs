

using PlantHere.Application.CQRS.Results;
using PlantHere.Application.Interfaces.Service;

namespace PlantHere.Infrastructure
{
    public class EmailService : IEmailService
    {
        public async Task<CustomResult<bool>> Send(string to, string message)
        {
            return CustomResult<bool>.Success(200, true);
        }
    }
}
