using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace PlantHere.Application.CQRS.Product.Queries.GetProductsByPage
{
    public class GetProductsByPageQueryHandler : IRequestHandler<GetProductsByPageQuery, CustomResult<IEnumerable<GetProductsByPageQueryResult>>>, IRequestPreProcessor<GetProductsByPageQuery>
    {
        private readonly IProductService _productService;

        private readonly IDistributedCache _distributedCache;

        public GetProductsByPageQueryHandler(IProductService productService, IDistributedCache distributedCache)
        {
            _productService = productService;
            _distributedCache = distributedCache;
        }

        public async Task<CustomResult<IEnumerable<GetProductsByPageQueryResult>>> Handle(GetProductsByPageQuery request, CancellationToken cancellationToken)
        {
            var value = await _distributedCache.GetAsync($"{request.Page}{request.PageSize}");
            var jsonToDeserialize = System.Text.Encoding.UTF8.GetString(value);
            var cachedResult = JsonSerializer.Deserialize<IEnumerable<GetProductsByPageQueryResult>>(jsonToDeserialize);
            return CustomResult<IEnumerable<GetProductsByPageQueryResult>>.Success(200, cachedResult);
        }

        public async Task Process(GetProductsByPageQuery request, CancellationToken cancellationToken)
        {
            var value = await _distributedCache.GetAsync($"{request.Page}{request.PageSize}");

            if (value == null)
            {
                // Serialize the response
                var products = await _productService.GetProductsByPage(request);
                byte[] objectToCache = JsonSerializer.SerializeToUtf8Bytes(products);

                // Cache it
                await _distributedCache.SetAsync($"{request.Page}{request.PageSize}", objectToCache);
            }
        }
    }
}


