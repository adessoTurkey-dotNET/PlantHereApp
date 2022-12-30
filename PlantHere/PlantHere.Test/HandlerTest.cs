using AutoMapper;
using FluentValidation;
using MediatR;
using Moq;
using PlantHere.Application.CQRS.Decorators;
using PlantHere.Application.CQRS.Product.Commands.CreateProduct;
using PlantHere.Application.CQRS.Product.Queries.GetAllProducts;
using PlantHere.Application.CQRS.Product.Queries.GetProductByUniqueId;
using PlantHere.Application.Interfaces.Service;
using PlantHere.Domain.Aggregate.CategoryAggregate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace PlantHere.Test
{
    public class HandlerTest
    {
        //Arrange


        private readonly Mock<IProductService> _productService;

        private readonly Product _product;

        private readonly Mock<IEnumerable<IValidator<CreateProductCommand>>> _validatios;

        private readonly Mock<IMapper> _autoMapper;

        private readonly Mock<ICategoryService> _categoryService;

        private readonly CreateProductCommand _command;

        private readonly CreateProductCommandHandler _handler; 

        public HandlerTest()
        {
            _validatios = new Mock<IEnumerable<IValidator<CreateProductCommand>>>();
            _categoryService = new Mock<ICategoryService>();
            _autoMapper = new Mock<IMapper>();
            _productService = new Mock<IProductService>();
            _product = new Product { Id = 1, Name = "Pachyphytum Oviferum", Description = "Baden Şekeri", Stock = 5, Price = 50, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 0 };
            _command = new CreateProductCommand {  Name = "Pachyphytum Oviferum", Description = "Baden Şekeri", Stock = 5, Price = 50,CategoryId = 2, SellerId = "d8a07002-0c3a-4add-874b-dd2b1e33aaae", Discount = 0 };
            _handler = new CreateProductCommandHandler(_productService.Object, _categoryService.Object, _validatios.Object, _autoMapper.Object);
        }

        [Fact]
        public async void CreateProductCommandHandler_handlerExecutes_ResultDataNotNullStatusCodeEqualCreatedAndErrorNull()
        {
            //Arrange

            _productService.Setup(m => m.AddAsync(_product)).ReturnsAsync(_product);
            _autoMapper.Setup(m => m.Map<Product>(_command)).Returns(_product);
            _autoMapper.Setup(m => m.Map<CreateProductCommandResult>(_product)).Returns(new CreateProductCommandResult { });

            //Act

            var resultProducts = await _handler.Handle(_command, new CancellationToken());

            //Assert

            Assert.Null(resultProducts.Errors);
            Assert.Equal(201, resultProducts.StatusCode);
            Assert.NotNull(resultProducts.Data);       
        }

    }
}
