using FluentAssertions;
using Greggs.Products.Api.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Greggs.Products.UnitTests.Unit
{
    [TestClass, TestCategory("Unit")]
    public class ProductAccessTests
    {
        [TestMethod]
        public void List_InputGBP_ReturnsExpectedResult()
        {
            // Arrange
            var productAccess = new ProductAccess();

            // Act
            var actual = productAccess.List(0, 5);

            // Assert
            actual.Should().HaveCount(5);
            actual.First().Name = "Coca Cola";
            actual.First().PriceInPounds = 1.2m;
        }
    }
}
