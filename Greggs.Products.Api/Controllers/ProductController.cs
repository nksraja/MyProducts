using Greggs.Products.Api.Models;
using Greggs.Products.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Greggs.Products.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="productService">The product service.</param>
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Get list of products order by latest.
        /// </summary>
        /// <param name="pageStart">Start from row.</param>
        /// <param name="pageSize">Required page size.</param>
        /// <param name="currency">The price in currency</param>
        /// <returns>Returns products.</returns>
        /// <response code="404">There is no resource found for the input.</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Product>> Get(int pageStart = 0, int pageSize = 5, string currency = "GBP")
        {
            var results = _productService.GetProducts(pageStart, pageSize, currency);
            if (results is null || results.Count() <=0)
            {
                return NotFound();
            }
            return Ok(results);
        }
    }
}
