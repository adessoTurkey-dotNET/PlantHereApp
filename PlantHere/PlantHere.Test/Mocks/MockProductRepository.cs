using Moq;
using PlantHere.Application.Interfaces.Repositories;
using PlantHere.Domain.Aggregate.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantHere.Test.Mocks
{
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            //Arrange
            var _products = new List<Product>() { new Product { Id = 1, Name = "Pachyphytum Oviferum", Description = "Baden Şekeri", Stock = 5, Price = 50, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 0 },
                            new Product { Id = 2, Name = "Echeveria Lola", Description = "Beyaz Renk Muhteşem Form", Stock = 2, Price = 75, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 15 },
                            new Product { Id = 3, Name = "Cremnosedum Little Gem", Description = "Güneşte Rengi Koyulaşır", Stock = 2, Price = 150, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 0 },
                            new Product { Id = 4, Name = "Callisia Repens (Pink Lady)", Description = "Pembe Yapraklı Telgraf Çiçeği", Stock = 3, Price = 100, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 25 },
                            new Product { Id = 5, Name = "Haworthia Fasciata Hibrid", Description = "Zebra Bitkisi", Stock = 2, Price = 45, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 20 } };

            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(_products);

            mockRepo.Setup(r => r.AddAsync((It.IsAny<Product>()))).Returns((Task.CompletedTask));

            return mockRepo;
        }
    }
}
