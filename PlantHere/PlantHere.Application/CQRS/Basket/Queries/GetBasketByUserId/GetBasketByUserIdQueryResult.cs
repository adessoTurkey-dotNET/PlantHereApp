using PlantHere.Application.CQRS.BasketItem.Queries.GetAllBasketItems;


namespace PlantHere.Application.CQRS.Basket.Queries.GetBasketByUserId
{
    public class GetBasketByUserIdQueryResult
    {
        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<GetAllBasketItemsQueryResult> BasketItems { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal DiscountedTotalPrice { get; set; }

    }
}
