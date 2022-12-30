using PlantHere.Domain.Aggregate.OrderAggregate.DomainEvents;
using PlantHere.Domain.Aggregate.OrderAggregate.ValueObjects;
using PlantHere.Domain.Common.Class;
using PlantHere.Domain.Common.Interfaces;

namespace PlantHere.Domain.Aggregate.OrderAggregate.Entities
{
    //EF Core features
    // -- Owned Types
    // -- Shadow Property
    // -- Backing Field
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }

        public Address Address { get; private set; }

        public string BuyerId { get; private set; }


        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order()
        {
        }

        public Order(string buyerId, Address address)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
            AddOrderStartedDomainEvent(BuyerId);
        }
        public Order(string buyerId, Address address, List<OrderItem> orderItems)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
            AddOrderItems(orderItems);
            AddOrderStartedDomainEvent(BuyerId);
        }

        public Order(int id, string buyerId, Address address)
        {
            Id = id;
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
            AddOrderStartedDomainEvent(BuyerId);
        }

        public void AddOrderItem(string productId, string productName, decimal price, decimal discountedPrice, int count)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);

            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, price, discountedPrice, count);

                _orderItems.Add(newOrderItem);
            }
        }

        public Order AddOrder(List<OrderItem> orderItems)
        {
            var order = new Order(BuyerId, Address);

            order.AddOrderItems(orderItems);

            AddDomainEvent(new OrderStartedDomainEvent(order, BuyerId));

            return order;
        }

        public void AddOrderItems(List<OrderItem> orderItems)
        {
            foreach (var orderItem in orderItems)
            {
                _orderItems.Add(orderItem);
            }
        }

        public void UpdateOrder(string buyerId, Address address, List<OrderItem> orderItems)
        {
            BuyerId = buyerId;
            Address = address;

            foreach (var orderItem in orderItems)
            {
                orderItem.UpdateOrderItem(orderItem.ProductName, orderItem.Price, orderItem.Count);
            }
        }

        public decimal GetTotalPrice()
        {
            return _orderItems.Sum(x => x.Price * x.Count);
        }

        public decimal GetDiscountedTotalPrice()
        {
            return _orderItems.Sum(x => x.DiscountedPrice * x.Count);
        }

        private void AddOrderStartedDomainEvent(string buyerId)
        {
            var orderStartedDomainEvent = new OrderStartedDomainEvent(this, buyerId);

            this.AddDomainEvent(orderStartedDomainEvent);
        }

    }

}