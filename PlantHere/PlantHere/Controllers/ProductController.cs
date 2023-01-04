using Microsoft.Extensions.Hosting;
using Nest;
using PlantHere.Application.CQRS.Product.Commands.CreateProduct;
using PlantHere.Application.CQRS.Product.Commands.DeleteProduct;
using PlantHere.Application.CQRS.Product.Commands.UpdateProduct;
using PlantHere.Application.CQRS.Product.Queries.GetAll;
using PlantHere.Application.CQRS.Product.Queries.GetAllProducts;
using PlantHere.Application.CQRS.Product.Queries.GetProductByUniqueId;
using PlantHere.Application.CQRS.Product.Queries.GetProductsByPage;
using PlantHere.Application.CQRS.Product.Queries.GetProductsCount;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace PlantHere.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IMediator _mediator;

        private readonly IElasticClient _elasticClient;

        private readonly IDistributedCache _distributedCache;

        public ProductController(IMediator mediator, IElasticClient elasticClient, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _elasticClient = elasticClient;
            _distributedCache = distributedCache;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return CreateActionResult(CustomResult<IEnumerable<GetAllProductsQueryResult>>.Success(200, products));
        }

        [AllowAnonymous]
        [HttpGet("{uniqueId}")]
        public async Task<IActionResult> GetProductByUniqueId(string uniqueId)
        {
            return CreateActionResult(await _mediator.Send(new GetProductByUniqueIdQuery(uniqueId)));
        }


        [AllowAnonymous]
        [HttpGet("[action]/{page}/{pageSize}")]
        public async Task<IActionResult> GetProductsByPage(int page, int pageSize)
        {
            return CreateActionResult(await _mediator.Send(new GetProductsByPageQuery(page, pageSize)));
        }

        [AllowAnonymous]
        [HttpGet("[action]/{keyword}")]
        public async Task<IActionResult> GetProductES(string keyword)
        {
            var result = await _elasticClient.SearchAsync<GetAllProductsQueryResult>(
                        s => s.Query(
                            q => q.QueryString(
                                d => d.Query('*' + keyword + '*')
                            )).Size(5));

            return CreateActionResult(CustomResult<List<GetAllProductsQueryResult>>.Success(200,result.Documents.ToList()));
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> CreateProductsIndex()
        {
            await _elasticClient.Indices.DeleteAsync("products");

            var products = await _mediator.Send(new GetAllProductsQuery());

            _elasticClient.Bulk(b => b
             .Index("products")
             .IndexMany(products));

            return CreateActionResult(CustomResult<GetAllProductsQueryResult>.Success(200,null));
        }


        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsCount()
        {
            return CreateActionResult(await _mediator.Send(new GetProductsCountQuery()));
        }

        [Authorize(Roles = "superadmin,seller")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return CreateActionResult(CustomResult<GetProductByUniqueIdQueryResult>.Success(204));
        }

        [Authorize(Roles = "superadmin,seller")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            return CreateActionResult(await _mediator.Send(command));
        }

        [Authorize(Roles = "superadmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return CreateActionResult(CustomResult<DeleteProductCommand>.Success(204));
        }

    }
}
