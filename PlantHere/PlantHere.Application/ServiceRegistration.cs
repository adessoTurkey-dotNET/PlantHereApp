using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PlantHere.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            // MediatR
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

            // Auto Mapper
            serviceCollection.AddAutoMapper(typeof(ServiceRegistration));

            // Validators
            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
