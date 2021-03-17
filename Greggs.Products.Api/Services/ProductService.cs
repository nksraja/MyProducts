using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Greggs.Products.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IDataAccess<ProductDb> _dataAccess;

        private const decimal _exchangeEuroRate = 1.11m;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService" /> class.
        /// </summary>
        /// <param name="dataAccess">The product data access.</param>
        public ProductService(IDataAccess<ProductDb> dataAccess)
        {
            _dataAccess = dataAccess;
        }

        /// <inheritdoc/>
        public IEnumerable<Product> GetProducts(int pageStart, int pageSize, string currency)
        {
            var products = _dataAccess.List(pageStart, pageSize);
            decimal exchangeRate = 1;
            if (currency.ToUpper() != "GBP")
            {
                exchangeRate = _exchangeEuroRate;
                currency = "EUR";
            }

            return from p in products
                    select (new Product { Name = p.Name, Price = p.PriceInPounds * exchangeRate, Currency = currency });
        }
    }
}
