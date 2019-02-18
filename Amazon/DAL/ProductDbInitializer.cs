using Amazon.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Amazon.DAL
{
    public class ProductDbInitializer : CreateDatabaseIfNotExists<ProductDbContext>
    {
        protected override void Seed(ProductDbContext context)
        {
            var products = new List<Product>
            {
                new Product { ItemId = 1, Name = "Blue Sweater", Description = "Dolman Sleeve, Ribbed Top", Price = 35.00},
                new Product { ItemId = 2, Name = "Pink Socks", Description = "Sports style", Price = 6.99},
                new Product { ItemId = 3, Name = "Black Hat", Description = "Fedora", Price = 55.00},
                new Product { ItemId = 4, Name = "Woven Scarf", Description = "Leopard Print", Price = 20.00},
                new Product { ItemId = 5, Name = "Brown Ankle Bootie", Description = "Waterproof Suede", Price = 65.00},
                new Product { ItemId = 6, Name = "Green Wallet", Description = "Leather Credit Card", Price = 26.00},
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}