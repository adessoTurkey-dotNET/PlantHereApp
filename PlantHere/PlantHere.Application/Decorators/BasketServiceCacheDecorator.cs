using Microsoft.Extensions.Caching.Memory;
using PlantHere.Application.CQRS.Basket.Commands.BuyBasket;
using PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem;
using PlantHere.Domain.Aggregate.BasketAggregate.Entities;

namespace PlantHere.Application.Decorators
{
    public class BasketServiceCacheDecorator : BaseBasketServiceDecorator
    {
        private readonly IMemoryCache _memoryCache;

        private const string basketCacheName = "baskets";


        public BasketServiceCacheDecorator(IBasketService basketService, IMemoryCache memoryCache) : base(basketService)
        {
            _memoryCache = memoryCache;
        }

        public override async Task<Basket> AddAsync(Basket entity)
        {
            await base.AddAsync(entity);
            await UpdateCache();
            return entity;
        }

        public override async Task<CustomResult<BuyBasketCommandResult>> BuyBasket(BuyBasketCommand buyBasketCommand)
        {
            var result = await base.BuyBasket(buyBasketCommand);
            await UpdateCache();
            return result;
        }

        public override async Task<CustomResult<CreateBasketItemCommandResult>> CreateBasketItem(CreateBasketItemCommand createBasketItemCammand)
        {
            var result = await base.CreateBasketItem(createBasketItemCammand);
            await UpdateCache();
            return result;
        }

        public override async Task<CustomResult<DeleteBasketItemCommandResult>> DeleteBasketItem(DeleteBasketItemCommand deleteBasketItemCammand)
        {
            var result = await base.DeleteBasketItem(deleteBasketItemCammand);
            await UpdateCache();
            return result;
        }

        public override async Task<IEnumerable<Basket>> GetAllAsync()
        {
            if (_memoryCache.TryGetValue(basketCacheName, out List<Basket> cacheBaskets))
            {
                return cacheBaskets;
            }

            await UpdateCache();

            return _memoryCache.Get<List<Basket>>(basketCacheName);
        }

        public override async Task RemoveAsync(Basket entity)
        {
            await base.RemoveAsync(entity);
            await UpdateCache();
        }

        public override async Task<bool> RemoveBasket(string userId)
        {
            var result = await base.RemoveBasket(userId);
            await UpdateCache();
            return result;
        }

        public override async Task<CustomResult<UpdateBasketItemCommandResult>> UpdateBasketItem(UpdateBasketItemCommand updateBasketItemCammand)
        {
            var result = await base.UpdateBasketItem(updateBasketItemCammand);
            await UpdateCache();
            return result;
        }

        private async Task UpdateCache()
        {
            _memoryCache.Set(basketCacheName, await base.GetAllAsync());
        }
    }
}
