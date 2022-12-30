using PlantHere.Domain.Aggregate.BasketAggregate.DomainEvents;
using PlantHere.Domain.Aggregate.OrderAggregate.ValueObjects;
using PlantHere.Domain.Common.Class;
using PlantHere.Domain.Common.Interfaces;

namespace PlantHere.Domain.Aggregate.BasketAggregate.Entities
{
    public class Basket : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }

        public string UserId { get; private set; }


        private readonly List<BasketItem> _basketItems;

        public IReadOnlyCollection<BasketItem> BasketItems => _basketItems;

        public Basket()
        {

        }

        public Basket(int id, string userId)
        {
            Id = id;
            _basketItems = new List<BasketItem>();
            CreatedDate = DateTime.Now;
            UserId = userId;
        }

        public Basket(string userId)
        {
            _basketItems = new List<BasketItem>();
            CreatedDate = DateTime.Now;
            UserId = userId;
        }


        public void AddBasketItem(string productId, string productName, decimal price, decimal discountedPrice)
        {
            var existProduct = _basketItems.FirstOrDefault(x => x.ProductId == productId);

            if (existProduct == null)
            {
                var newOrderItem = new BasketItem(productId, productName, price, discountedPrice);

                _basketItems.Add(newOrderItem);
            }
            else
            {
                UpdateBasketItem(existProduct);
            }
        }

        public void BuyBasket(Address address, int cardTypeId, string cardNumber, string cardSecurityNumber, string cardHolderName)
        {
            AddOrderStartedDomainEvent(this, address, cardTypeId, cardNumber, cardSecurityNumber, cardHolderName);
        }

        public void UpdateBasketItem(BasketItem basketItem)
        {
            basketItem.UpdateBasketItem(basketItem.ProductName, basketItem.Count + 1);
        }

        public void UpdateBasketItem(BasketItem basketItem, decimal price, int count)
        {
            basketItem.UpdateBasketItem(price, count);
        }


        public void UpdateBasketItem(BasketItem basketItem, int count)
        {
            basketItem.UpdateBasketItem(count);
        }

        public void DeleteBasketItem(List<BasketItem> basketItems)
        {

            foreach (var basketItem in basketItems)
            {
                _basketItems.Remove(basketItem);
            }
        }

        public decimal GetTotalPrice => _basketItems.Sum(x => x.Price * x.Count);

        public decimal GetDiscountedTotalPrice => _basketItems.Sum(x => x.DiscountedPrice * x.Count);

        private void AddOrderStartedDomainEvent(Basket basket, Address address, int cardTypeId, string cardNumber, string cardSecurityNumber, string cardHolderName)
        {
            var baketBuyStartedDomainEvent = new BaketBuyStartedDomainEvent(basket, address, cardTypeId, cardNumber, cardSecurityNumber, cardHolderName);

            this.AddDomainEvent(baketBuyStartedDomainEvent);
        }
    }
}
