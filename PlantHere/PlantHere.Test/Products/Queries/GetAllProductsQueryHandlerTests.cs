using AutoMapper;
using Moq;
using PlantHere.Application.CQRS.Product.Queries.GetAll;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Mapping;
using PlantHere.Test.Mocks;
using Xunit;

namespace PlantHere.Test.Products.Queries
{
    public class GetAllProductsQueryHandlerTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;

        public GetAllProductsQueryHandlerTests()
        {   
            //Arrange
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

        }


        [Fact]
        public async Task GetProductTest_HandlerExecutes_ResultNotNull()
        {
            //Act
            var handler = new GetAllProductsQueryHandler(_mockUow.Object, _mapper);

            var results = await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);

            //Assert
            Assert.NotNull(results);
        }

        [Fact]
        public async Task GetProductTest_HandlerExecutes_ResultDtoMustContainDescription()
        {
            //Act
            var handler = new GetAllProductsQueryHandler(_mockUow.Object, _mapper);

            var results = await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);

            //Assert

            Assert.All(results, result => Assert.NotEqual(string.Empty, result.Description));
        }


        [Fact]
        public async Task GetProductTest_HandlerExecutes_ResultCount5()
        {
            //Act
            var handler = new GetAllProductsQueryHandler(_mockUow.Object, _mapper);

            var result = await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);

            //Assert

            Assert.Equal(5,result.Count());
        }

    }
}
