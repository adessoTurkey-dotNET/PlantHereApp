namespace PlantHere.Application.CQRS.Product.Queries.GetAllProducts
{
    public class GetAllProductsQueryResult
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Discount { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountedPrice { get; set; }

        public string UniqueId { get; set; }

    }
}
