using System;

namespace Greggs.Products.Api.Models
{
    /// <summary>
    /// The product database model.
    /// </summary>
    public class ProductDb
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        /// <value>
        /// The product name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price in Pounds.
        /// </summary>
        /// <value>
        /// The price in Pounds.
        /// </value>
        public decimal PriceInPounds { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }
    }
}
