﻿
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlantHere.Infrastructure.Extensions.ElasticSearchExtensions;

namespace PlantHere.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            //  Scrutor
            serviceCollection.Scan(scan =>
            scan.FromCallingAssembly()
                .AddClasses()
                .AsMatchingInterface());

            // ES 
            serviceCollection.AddElasticsearch(configuration);
        }
    }
}