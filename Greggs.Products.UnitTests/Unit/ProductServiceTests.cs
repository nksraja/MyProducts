using FluentAssertions;
using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Models;
using Greggs.Products.Api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Greggs.Products.UnitTests.Unit
{
    [TestClass, TestCategory("Unit")]
    public class ProductServiceTests
    {
        private readonly Mock<IDataAccess<ProductDb>> _mockDataAccess
         = new Mock<IDataAccess<ProductDb>>(MockBehavior.Strict);

        [TestMethod]
        public void GetProducts_InputGBP_ReturnsExpectedResult()
        {
            // Arrange
            var expectedDataModel = ProductDatabase;
            _mockDataAccess
                .Setup(r => r.List(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(expectedDataModel)
                .Verifiable();
            var productService = GetProductService();

            // Act
            var actual = productService.GetProducts(0, 5, "GBP");
            // Assert
            actual.Should().HaveCount(8);
            actual.First().Currency = "GBP";
            actual.First().Price = 1m;
            _mockDataAccess.Verify(r => r.List(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetProducts_InputEUR_ReturnsExpectedResult()
        {
            // Arrange
            var expectedDataModel = ProductDatabase;
            _mockDataAccess
                .Setup(r => r.List(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(expectedDataModel)
                .Verifiable();
            var productService = GetProductService();

            // Act
            var actual = productService.GetProducts(0, 5, "EUR");
            // Assert
            actual.Should().HaveCount(8);
            actual.First().Currency = "EUR";
            actual.First().Price = 1.11m;
            _mockDataAccess.Verify(r => r.List(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        private ProductService GetProductService()
        {
            return new ProductService( _mockDataAccess.Object);
        }

        private static readonly IEnumerable<ProductDb> ProductDatabase = new List<ProductDb>()
        {
            new ProductDb {Name = "Sausage Roll", PriceInPounds = 1m, CreatedAt = DateTime.Now.AddDays(-8)},
            new ProductDb {Name = "Vegan Sausage Roll", PriceInPounds = 1.1m, CreatedAt = DateTime.Now.AddDays(-7)},
            new ProductDb {Name = "Steak Bake", PriceInPounds = 1.2m, CreatedAt = DateTime.Now.AddDays(-6)},
            new ProductDb {Name = "Yum Yum", PriceInPounds = 0.7m, CreatedAt = DateTime.Now.AddDays(-5)},
            new ProductDb {Name = "Pink Jammie", PriceInPounds = 0.5m, CreatedAt = DateTime.Now.AddDays(-4)},
            new ProductDb {Name = "Mexican Baguette", PriceInPounds = 2.1m, CreatedAt = DateTime.Now.AddDays(-3)},
            new ProductDb {Name = "Bacon Sandwich", PriceInPounds = 1.95m, CreatedAt = DateTime.Now.AddDays(-2)},
            new ProductDb {Name = "Coca Cola", PriceInPounds = 1.2m, CreatedAt = DateTime.Now.AddDays(-1)}
        };
    }
}
