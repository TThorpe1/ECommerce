using Amazon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Amazon.DAL
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base("ProductContext")
        {
            Database.SetInitializer(new ProductDbInitializer());
        }
        public DbSet<Product> Products { get; set; }
    }
}