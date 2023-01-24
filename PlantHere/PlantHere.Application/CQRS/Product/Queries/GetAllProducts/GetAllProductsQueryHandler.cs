using PlantHere.Application.CQRS.Product.Queries.GetAllProducts;
using PlantHere.Application.Interfaces;

namespace PlantHere.Application.CQRS.Product.Queries.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<GetAllProductsQueryResult>>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetAllProductsQueryResult>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetAsync();
            return _mapper.Map<IEnumerable<GetAllProductsQueryResult>>(products);
        }
    }
}
