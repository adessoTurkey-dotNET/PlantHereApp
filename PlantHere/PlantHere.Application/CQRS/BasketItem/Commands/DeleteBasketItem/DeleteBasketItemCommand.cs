namespace PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommand : IRequest<CustomResult<DeleteBasketItemCommandResult>>
    {
        public string? UserId { get; set; }

        public string ProductId { get; set; }
    }
}
