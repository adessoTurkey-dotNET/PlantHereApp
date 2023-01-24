using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace PlantHere.Application.CQRS.Product.Queries.GetProductsByPage
{
    public class GetProductsByPageQueryHandler : IRequestHandler<GetProductsByPageQuery, IEnumerable<GetProductsByPageQueryResult>>, IRequestPreProcessor<GetProductsByPageQuery>
    {
        private readonly IProductRepository _productRepository;

        private readonly IDistributedCache _distributedCache;

        private readonly IMapper _mapper;

        public GetProductsByPageQueryHandler(IProductRepository productService, IDistributedCache distributedCache, IMapper mapper)
        {
            _productRepository = productService;
            _distributedCache = distributedCache;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductsByPageQueryResult>> Handle(GetProductsByPageQuery request, CancellationToken cancellationToken)
        {
            var value = await _distributedCache.GetAsync($"{request.Page}{request.PageSize}");
            var jsonToDeserialize = System.Text.Encoding.UTF8.GetString(value);
            var cachedResult = JsonSerializer.Deserialize<IEnumerable<GetProductsByPageQueryResult>>(jsonToDeserialize);
            return cachedResult;
        }

        public async Task Process(GetProductsByPageQuery request, CancellationToken cancellationToken)
        {
            //_distributedCache.Remove($"{request.Page}{request.PageSize}");
            var value = await _distributedCache.GetAsync($"{request.Page}{request.PageSize}");

            if (value == null)
            {
                // Serialize the response

                var products = _mapper.Map<ICollection<GetProductsByPageQueryResult>>(await _productRepository.GetProductsByPage(request.Page, request.PageSize));
                byte[] objectToCache = JsonSerializer.SerializeToUtf8Bytes(products);

                // Cache it
                await _distributedCache.SetAsync($"{request.Page}{request.PageSize}", objectToCache);
            }
        }
    }
}


