namespace PlantHere.Application.CQRS.Product.Queries.GetProductByUniqueId
{
    public class GetProductByUniqueIdQuery : IRequest<CustomResult<GetProductByUniqueIdQueryResult>>
    {
        public string UniqueId { get; set; }

        public GetProductByUniqueIdQuery(string uniqueId)
        {
            UniqueId = uniqueId;
        }
    }
}
