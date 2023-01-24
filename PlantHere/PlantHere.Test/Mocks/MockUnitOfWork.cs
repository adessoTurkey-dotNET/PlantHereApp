using Moq;
using PlantHere.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantHere.Test.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {   
            //Arrange
            var mockUow = new Mock<IUnitOfWork>();
            var mockProductRepo = MockProductRepository.GetProductRepository();
            mockUow.Setup(r => r.ProductRepository).Returns(mockProductRepo.Object);
            return mockUow;

        }
    }
}
