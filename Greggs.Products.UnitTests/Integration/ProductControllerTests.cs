using FluentAssertions;
using Greggs.Products.Api;
using Greggs.Products.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Greggs.Products.UnitTests.Integration
{
    [TestClass]
    [TestCategory("Integration")]
    public class ProductControllerTests
    {
        private readonly HttpClient _testClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductControllerTests"/> class.
        /// </summary>
        public ProductControllerTests()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _testClient = appFactory.CreateClient();
            _testClient.BaseAddress = new Uri("http://localhost:5001");
            _testClient.DefaultRequestHeaders.Accept.Clear();
            _testClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [TestMethod]
        public async Task Get_WithDefaultParameters_ReturnsOK()
        {
            // Arrange
            string parms = $"?pageStart=0&pageSize=5&currency=GBP";

            // Act
            var response = await _testClient.GetAsync("/api/Product" + parms);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            string productsString = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(productsString);
            products.Should().NotBeNull();
            products.Should().HaveCount(5);
        }


        [TestMethod]
        public async Task Get_ReturnsNotFound()
        {
            // Arrange
            string parms = $"?pageStart=10&pageSize=5&currency=GBP";

            // Act
            var response = await _testClient.GetAsync("/api/Product" + parms);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

    }
}
