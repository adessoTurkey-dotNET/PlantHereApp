namespace PlantHere.Application.CQRS.Product.Queries.GetProductsByPage
{
    public class GetProductsByPageQuery : IRequest<CustomResult<IEnumerable<GetProductsByPageQueryResult>>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public GetProductsByPageQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }



}
