using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlantHere.Persistence.Extensions.RabbitMQExtensions;
using System.Reflection;

namespace PlantHere.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {

            // DB
            serviceCollection.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration?.GetConnectionString("SQLConnection").Trim(), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name);

                });
            });

            // CAP
            serviceCollection.AddRabbitMQ(configuration);



            // MemoryCache
            serviceCollection.AddMemoryCache();

            // Scrutor
            serviceCollection.Scan(scan =>
            scan.FromCallingAssembly()
                .AddClasses()
                .AsMatchingInterface());

            // MediatR
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());


        }
    }
}

