using Greggs.Products.Api.Models;
using System.Collections.Generic;

namespace Greggs.Products.Api.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Get paged products by the latest.
        /// </summary>
        /// <param name="pageStart">Start from row.</param>
        /// <param name="pageSize">Required page size.</param>
        /// <returns></returns>
        IEnumerable<Product> GetProducts(int pageStart, int pageSize, string currency);
    }
}
