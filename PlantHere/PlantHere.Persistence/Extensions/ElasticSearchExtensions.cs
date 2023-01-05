using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using PlantHere.Application.Configurations;
using PlantHere.Application.CQRS.Product.Queries.GetAllProducts;

namespace PlantHere.Persistence.NewFolder
{

    public static class ElasticSearchExtensions
    {
        public static void AddElasticsearch(
            this IServiceCollection services, IConfiguration configuration)
        {

            var eSConfiguration = configuration.GetSection("ESConfiguration").Get<ESConfiguration>();

            var url = eSConfiguration.Url;
            var defaultIndex = "products";

            var settings = new ConnectionSettings(new Uri(url))
                .PrettyJson()
                .DefaultIndex(defaultIndex);

            AddDefaultMappings(settings);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, defaultIndex);
        }

        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings
                .DefaultMappingFor<GetAllProductsQueryResult>(m => m);
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<GetAllProductsQueryResult>(x => x.AutoMap())
            );
        }
    }
}
