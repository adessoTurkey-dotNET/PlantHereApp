using PlantHere.Application.CQRS.Address.Queries;
using PlantHere.Application.CQRS.Payment.Quries;

namespace PlantHere.Application.CQRS.Basket.Commands.BuyBasket
{
    public class BuyBasketCommand : IRequest<CustomResult<BuyBasketCommandResult>>
    {
        public string? UserId { get; set; }

        public AddressQueryResult Address { get; set; }

        public PaymentQueryResult Payment { get; set; }

    }
}
