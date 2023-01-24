namespace PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem
{
    public class CreateBasketItemCommand : IRequest<CreateBasketItemCommandResult>
    {
        public string ProductId { get; set; }

        public string? UserId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountedPrice { get; set; }

    }
}
