using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlantHere.Application.Configurations;

namespace PlantHere.Persistence.Extensions
{
    public static class RabbitMQExtensions
    {
        public static void AddRabbitMQ(
          this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMQConfiguration = configuration.GetSection("RabbitMQConfiguration").Get<RabbitMQConfiguration>();

            services.AddCap(options =>
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
        }
    }
}
