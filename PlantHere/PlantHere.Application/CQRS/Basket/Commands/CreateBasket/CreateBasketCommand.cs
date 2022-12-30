namespace PlantHere.Application.CQRS.Basket.Commands.CreateBasket
{
    public class CreateBasketCommand : IRequest<CustomResult<CreateBasketCommandResult>>
    {
        public string UserId { get; set; }

        public CreateBasketCommand(string userId)
        {
            UserId = userId;
        }
    }
}
