namespace PlantHere.Application.CQRS.Product.Queries.GetProductByUniqueId
{
    public class GetProductByUniqueIdQueryHandler : IRequestHandler<GetProductByUniqueIdQuery, GetProductByUniqueIdQueryResult>
    {

        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public GetProductByUniqueIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GetProductByUniqueIdQueryResult> Handle(GetProductByUniqueIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<GetProductByUniqueIdQueryResult>(await _productRepository.GetProductByUniqueIdWithImages(request.UniqueId));
        }
    }
}
