using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlantHere.Application.CQRS.Decorators;
using PlantHere.Application.Decorators;
using PlantHere.Application.Services;
using PlantHere.Persistence.Services;
using System.Reflection;

namespace PlantHere.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            serviceCollection.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration?.GetConnectionString("SQLConnection").Trim(), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name);
                });
            });

            // Decorators

            serviceCollection.AddMemoryCache();

            // Decorator Scrutor

            serviceCollection.Scan(scan =>
            scan.FromCallingAssembly()
                .AddClasses()
                .AsMatchingInterface());

            serviceCollection.AddScoped<IProductService, ProductService>().
                Decorate<IProductService, ProductServiceCacheDecorator>().
                Decorate<IProductService, ProductServiceLoggingDecorator>();

            serviceCollection.AddScoped<ICategoryService, CategoryService>().
              Decorate<ICategoryService, CategoryServiceCacheDecorator>();

            serviceCollection.AddScoped<IBasketService, BasketService>().
            Decorate<IBasketService, BasketServiceCacheDecorator>();

            // MediatR
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
