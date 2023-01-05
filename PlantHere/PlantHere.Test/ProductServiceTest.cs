using AutoMapper;
using Moq;
using PlantHere.Application.CQRS.Product.Queries.GetProductsByPage;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Repositories;
using PlantHere.Application.Services;
using PlantHere.Domain.Aggregate.CategoryAggregate;
using Xunit;

namespace PlantHere.Test
{
    public class ProductServiceTest
    {
        // Arrange

        // Mock
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IRepository<Product>> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;

        // Service

        private readonly ProductService _productService;

        // CQRS

        private readonly List<GetProductsByPageQueryResult> _getProductsByPageQueryResult;

        // Model 

        private readonly List<Product> _products;

        public ProductServiceTest()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockProductRepository = new Mock<IProductRepository>();
            _mockRepository = new Mock<IRepository<Product>>();
            _mockMapper = new Mock<IMapper>();
            _productService = new ProductService(_mockRepository.Object, _mockUnitOfWork.Object, _mockProductRepository.Object, _mockMapper.Object);

            _products = new List<Product>() { new Product { Id = 1, Name = "Pachyphytum Oviferum", Description = "Baden Şekeri", Stock = 5, Price = 50, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 0 },
                            new Product { Id = 2, Name = "Echeveria Lola", Description = "Beyaz Renk Muhteşem Form", Stock = 2, Price = 75, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 15 },
                            new Product { Id = 3, Name = "Cremnosedum Little Gem", Description = "Güneşte Rengi Koyulaşır", Stock = 2, Price = 150, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 0 },
                            new Product { Id = 4, Name = "Callisia Repens (Pink Lady)", Description = "Pembe Yapraklı Telgraf Çiçeği", Stock = 3, Price = 100, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 25 },
                            new Product { Id = 5, Name = "Haworthia Fasciata Hibrid", Description = "Zebra Bitkisi", Stock = 2, Price = 45, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 20 } };

            _getProductsByPageQueryResult = new List<GetProductsByPageQueryResult>() { new GetProductsByPageQueryResult { Name = "Pachyphytum Oviferum", Description = "Baden Şekeri", Price = 50,  Discount = 0 },
                            new GetProductsByPageQueryResult { Name = "Echeveria Lola", Description = "Beyaz Renk Muhteşem Form",  Price = 75, Discount = 15 },
                            new GetProductsByPageQueryResult { Name = "Cremnosedum Little Gem", Description = "Güneşte Rengi Koyulaşır",  Price = 150,  Discount = 0 },
                            new GetProductsByPageQueryResult { Name = "Callisia Repens (Pink Lady)", Description = "Pembe Yapraklı Telgraf Çiçeği", Discount = 25 },
                            new GetProductsByPageQueryResult { Name = "Haworthia Fasciata Hibrid", Description = "Zebra Bitkisi",  Discount = 20 } };
        }



        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async void GetProductsByPage_ActionExecutes_ResultNotNull(int page)
        {
            // Arrange

            _mockProductRepository.Setup(x => x.GetProductsByPage(page, 5)).ReturnsAsync(_products);

            _mockMapper.Setup(x => x.Map<ICollection<GetProductsByPageQueryResult>>(_products)).Returns(_getProductsByPageQueryResult);

            // Act

            var resultProducts = await _productService.GetProductsByPage(new GetProductsByPageQuery(page, 5));

            //Assert

            Assert.NotNull(resultProducts);
        }

    }
}

