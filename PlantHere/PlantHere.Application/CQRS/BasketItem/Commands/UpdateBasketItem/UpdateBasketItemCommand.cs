namespace PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem
{
    public class UpdateBasketItemCommand : IRequest<CustomResult<UpdateBasketItemCommandResult>>
    {
        public string ProductId { get; set; }

        public string? UserId { get; set; }

        public int Count { get; set; }
    }
}
