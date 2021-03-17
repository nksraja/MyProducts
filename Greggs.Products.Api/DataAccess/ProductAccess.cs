using System;
using System.Collections.Generic;
using System.Linq;
using Greggs.Products.Api.Models;

namespace Greggs.Products.Api.DataAccess
{
    /// <summary>
    /// DISCLAIMER: This is only here to help enable the purpose of this exercise, this doesn't reflect the way we work!
    /// </summary>
    public class ProductAccess : IDataAccess<ProductDb>
    {
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

        public IEnumerable<ProductDb> List(int? pageStart, int? pageSize)
        {
            IQueryable<ProductDb> queryable = ProductDatabase.AsQueryable().OrderByDescending(p => p.CreatedAt);

            if (pageStart.HasValue)
                queryable = queryable.Skip(pageStart.Value);

            if (pageSize.HasValue)
                queryable = queryable.Take(pageSize.Value);

            return queryable.ToList();
        }
    }
}