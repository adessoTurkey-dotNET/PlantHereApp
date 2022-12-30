using Microsoft.EntityFrameworkCore;
using PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem;
using PlantHere.Domain.Aggregate.BasketAggregate.Entities;

namespace PlantHere.Persistence.Repositories
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        public BasketRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Basket> GetBasketByUserId(string UserId)
        {
            return await _context.Basket.Include(x => x.BasketItems).FirstOrDefaultAsync(x => x.UserId == UserId);
        }

        public async Task<bool> CreateBasketItem(CreateBasketItemCommand createBasketItemCammand)
        {
            var basket = await _context.Basket.Include(x => x.BasketItems).FirstOrDefaultAsync(X => X.UserId == createBasketItemCammand.UserId);

            if (basket == null) throw new NotFoundException($"{typeof(Basket).Name}({createBasketItemCammand.UserId}) Not Found");

            basket.AddBasketItem(createBasketItemCammand.ProductId, createBasketItemCammand.ProductName, createBasketItemCammand.Price, createBasketItemCammand.DiscountedPrice);

            return true;

        }

        public async Task<bool> DeleteBasketItem(DeleteBasketItemCommand deleteBasketItemCommand)
        {
            var basket = await _context.Basket.Include(x => x.BasketItems).FirstOrDefaultAsync(X => X.UserId == deleteBasketItemCommand.UserId);

            if (basket == null) throw new NotFoundException($"{typeof(Basket).Name}({deleteBasketItemCommand.UserId}) Not Found");

            var basketItems = basket.BasketItems.Where(x => x.ProductId == deleteBasketItemCommand.ProductId).ToList();

            if (basketItems == null) throw new NotFoundException($"{typeof(BasketItem).Name}({deleteBasketItemCommand.ProductId}) Not Found");

            basket.DeleteBasketItem(basketItems);

            return true;
        }

        public async Task<bool> UpdateBasketItem(UpdateBasketItemCommand updateBasketItemCammand)
        {
            var basket = await _context.Basket.Include(x => x.BasketItems).FirstOrDefaultAsync(x => x.UserId == updateBasketItemCammand.UserId);

            if (basket == null || basket.BasketItems == null) throw new NotFoundException($"{typeof(Basket).Name}({updateBasketItemCammand.UserId}) Not Found");

            var basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == updateBasketItemCammand.ProductId);

            if (basketItem == null) throw new NotFoundException($"{typeof(BasketItem).Name}({updateBasketItemCammand.ProductId}) Not Found");

            basket.UpdateBasketItem(basketItem, updateBasketItemCammand.Count);

            return true;
        }

    }
}
