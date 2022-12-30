using PlantHere.Application.CQRS.Basket.Commands.BuyBasket;
using PlantHere.Application.CQRS.Basket.Queries.GetBasketByUserId;
using PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem;
using PlantHere.Domain.Aggregate.BasketAggregate.Entities;

namespace PlantHere.Application.Interfaces.Service
{
    public interface IBasketService : IService<Basket>
    {
        Task<CustomResult<GetBasketByUserIdQueryResult>> GetBasketsByUserIdAsync(string userId);

        Task<CustomResult<CreateBasketItemCommandResult>> CreateBasketItem(CreateBasketItemCommand createBasketItemCammand);

        Task<CustomResult<DeleteBasketItemCommandResult>> DeleteBasketItem(DeleteBasketItemCommand deleteBasketItemCammand);

        Task<CustomResult<UpdateBasketItemCommandResult>> UpdateBasketItem(UpdateBasketItemCommand updateBasketItemCammand);

        Task<CustomResult<BuyBasketCommandResult>> BuyBasket(BuyBasketCommand buyBasketCommand);

        Task<bool> RemoveBasket(string userId);
    }
}
