using Nest;
using PlantHere.Application.CQRS.Product.Queries.GetProductsES;
using PlantHere.Application.Interfaces;

namespace PlantHere.Application.CQRS.Product.Commands.CreateProductsIndexES
{
    public class CreateProductsIndexESCommandHandler : IRequestHandler<CreateProductsIndexESCommand, CreateProductsIndexESCommandResult>
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IElasticClient _elasticClient;

        private readonly IMapper _mapper;

        public CreateProductsIndexESCommandHandler(IUnitOfWork unitOfWork, IElasticClient elasticClient, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _elasticClient = elasticClient;
            _mapper = mapper;
        }

        public async Task<CreateProductsIndexESCommandResult> Handle(CreateProductsIndexESCommand request, CancellationToken cancellationToken)
        {
            await _elasticClient.Indices.DeleteAsync("products");

            var products = _mapper.Map<ICollection<GetProductsESQueryResult>>(_unitOfWork.ProductRepository.GetAll());

            _elasticClient.Bulk(b => b
             .Index("products")
             .IndexMany(products));

            return new CreateProductsIndexESCommandResult();
        }
    }
}
