using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlantHere.Application.Configurations;
using PlantHere.Application.Decorators;
using PlantHere.Persistence.NewFolder;
using PlantHere.Persistence.Repositories;
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

            // Redis

            var redisCongfiguration = configuration.GetSection("RedisConfiguration").Get<RedisConfiguration>();

            serviceCollection.AddStackExchangeRedisCache(options => options.Configuration = redisCongfiguration.Url);

            // CAP
            var rabbitMQConfiguration = configuration.GetSection("RabbitMQConfiguration").Get<RabbitMQConfiguration>();

            serviceCollection.AddCap(options =>
            {
                options.UseEntityFramework<AppDbContext>();
                options.UseSqlServer(configuration?.GetConnectionString("SQLConnection"));
                options.UseRabbitMQ(options =>
                {
                    options.ConnectionFactoryOptions = options =>
                    {
                        options.Ssl.Enabled = false;
                        options.HostName = rabbitMQConfiguration.HostName;
                        options.UserName = rabbitMQConfiguration.UserName;
                        options.Password = rabbitMQConfiguration.Password;
                        options.Port = rabbitMQConfiguration.Port;
                    };
                });
                options.UseDashboard(o => o.PathMatch = "/cap");
            });

            // Decorators
            serviceCollection.AddMemoryCache();

            // Decorator Scrutor
            serviceCollection.Scan(scan =>
            scan.FromCallingAssembly()
                .AddClasses()
                .AsMatchingInterface());

            serviceCollection.AddScoped<IProductRepository, ProductRepository>().
                Decorate<IProductRepository, ProductRepositoryCacheDecorator>().
                Decorate<IProductRepository, ProductRepositoryLoggingDecorator>();


            // MediatR
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

            //ES 
            serviceCollection.AddElasticsearch(configuration);
        }
    }
}

