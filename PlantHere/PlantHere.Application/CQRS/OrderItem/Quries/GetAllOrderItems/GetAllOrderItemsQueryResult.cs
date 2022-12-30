namespace PlantHere.Application.CQRS.OrderItem.Queries.GetAllOrderItems
{
    public class GetAllOrderItemsQueryResult
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int Count { get; set; }
    }
}
