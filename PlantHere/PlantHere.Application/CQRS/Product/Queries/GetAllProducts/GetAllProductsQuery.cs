using PlantHere.Application.CQRS.Product.Queries.GetAllProducts;

namespace PlantHere.Application.CQRS.Product.Queries.GetAll
{
    public class GetAllProductsQuery : IRequest<IEnumerable<GetAllProductsQueryResult>>
    {
    }
}
