using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Queries;
using ModelProduct = PlantHere.Domain.Aggregate.CategoryAggregate.Product;

namespace PlantHere.Application.CQRS.Product.Queries.GetProductsByPage
{
    public class GetProductsByPageQueryHandler : IQueryHandler<GetProductsByPageQuery, IEnumerable<GetProductsByPageQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IDistributedCache _distributedCache;

        private readonly IMapper _mapper;

        public GetProductsByPageQueryHandler(IUnitOfWork unitOfWork, IDistributedCache distributedCache, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _distributedCache = distributedCache;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductsByPageQueryResult>> Handle(GetProductsByPageQuery request, CancellationToken cancellationToken)
        {
            var products = _mapper.Map<ICollection<GetProductsByPageQueryResult>>(await _unitOfWork.GetGenericRepository<ModelProduct>().GetQueryable().Include(x => x.Images).OrderBy(x => x.Id).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync());

            return products;
        }

    }
}


