using PlantHere.Application.CQRS.Basket.Commands.BuyBasket;
using PlantHere.Application.CQRS.Basket.Queries.GetBasketByUserId;
using PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem;
using PlantHere.Domain.Aggregate.BasketAggregate.Entities;
using System.Linq.Expressions;

namespace PlantHere.Application.Decorators
{
    public class BaseBasketServiceDecorator : IBasketService
    {

        private readonly IBasketService _basketService;

        public BaseBasketServiceDecorator(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public virtual async Task<Basket> AddAsync(Basket entity)
        {
            await _basketService.AddAsync(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<Basket>> AddRangeAsync(IEnumerable<Basket> entities)
        {
            await _basketService.AddRangeAsync(entities);
            return entities;
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<Basket, bool>> expression)
        {
            return await _basketService.AnyAsync(expression);
        }

        public virtual async Task<CustomResult<BuyBasketCommandResult>> BuyBasket(BuyBasketCommand buyBasketCommand)
        {
            return await _basketService.BuyBasket(buyBasketCommand);
        }

        public virtual async Task<CustomResult<CreateBasketItemCommandResult>> CreateBasketItem(CreateBasketItemCommand createBasketItemCammand)
        {
            return await _basketService.CreateBasketItem(createBasketItemCammand);
        }

        public virtual async Task<CustomResult<DeleteBasketItemCommandResult>> DeleteBasketItem(DeleteBasketItemCommand deleteBasketItemCammand)
        {
            return await _basketService.DeleteBasketItem(deleteBasketItemCammand);
        }

        public virtual async Task<IEnumerable<Basket>> GetAllAsync()
        {
            return await _basketService.GetAllAsync();
        }

        public virtual async Task<CustomResult<GetBasketByUserIdQueryResult>> GetBasketsByUserIdAsync(string userId)
        {
            return await _basketService.GetBasketsByUserIdAsync(userId);
        }

        public virtual async Task<Basket> GetByIdAsync(int id)
        {
            return await _basketService.GetByIdAsync(id);
        }

        public virtual async Task RemoveAsync(Basket entity)
        {
            await _basketService.RemoveAsync(entity);
        }

        public virtual async Task<bool> RemoveBasket(string userId)
        {
            return await _basketService.RemoveBasket(userId);
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<Basket> entities)
        {
            await _basketService.RemoveRangeAsync(entities);
        }

        public virtual async Task UpdateAsync(Basket entity)
        {
            await _basketService.UpdateAsync(entity);
        }

        public virtual async Task<CustomResult<UpdateBasketItemCommandResult>> UpdateBasketItem(UpdateBasketItemCommand updateBasketItemCammand)
        {
            return await _basketService.UpdateBasketItem(updateBasketItemCammand);
        }

        public virtual IQueryable<Basket> Where(Expression<Func<Basket, bool>> expression)
        {
            return _basketService.Where(expression);
        }
    }
}
