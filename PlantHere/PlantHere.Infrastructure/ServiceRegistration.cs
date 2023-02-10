
using Microsoft.Extensions.DependencyInjection;

namespace PlantHere.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            //  Scrutor
            serviceCollection.Scan(scan =>
            scan.FromCallingAssembly()
                .AddClasses()
                .AsMatchingInterface());

        }
    }
}