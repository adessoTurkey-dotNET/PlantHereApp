using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Queries;
using ModelProduct = PlantHere.Domain.Aggregate.CategoryAggregate.Product;

namespace PlantHere.Application.CQRS.Product.Queries.GetProductsCount
{
    public class GetProductsCountQueryHandler : IQueryHandler<GetProductsCountQuery, GetProductsCountQueryResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductsCountQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetProductsCountQueryResult> Handle(GetProductsCountQuery request, CancellationToken cancellationToken)
        {
            var count = _unitOfWork.GetGenericRepository<ModelProduct>().GetQueryable().Count();
            return new GetProductsCountQueryResult(count);
        }
    }
}
