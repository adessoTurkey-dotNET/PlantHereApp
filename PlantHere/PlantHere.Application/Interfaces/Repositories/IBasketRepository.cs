using PlantHere.Application.CQRS.Basket.Commands.BuyBasket;
using PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem;
using PlantHere.Domain.Aggregate.BasketAggregate.Entities;

namespace PlantHere.Application.Interfaces.Repositories
{
    public interface IBasketRepository : IRepository<Basket>
    {
        Task<Basket> GetBasketByUserId(string UserId);
        Task<bool> DeleteBasketItem(DeleteBasketItemCommand deleteBasketItemCommand);
        Task<bool> CreateBasketItem(CreateBasketItemCommand createBasketItemCammand);
        Task<bool> UpdateBasketItem(UpdateBasketItemCommand updateBasketItemCammand);
        Task<Basket> BuyBasket(BuyBasketCommand buyBasketCommand);
    }
}
