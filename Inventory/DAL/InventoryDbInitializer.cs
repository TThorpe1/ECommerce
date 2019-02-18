using System.Collections.Generic;
using System.Data.Entity;

namespace Inventory.DAL
{
    public class InventoryDbInitializer : CreateDatabaseIfNotExists<InventoryDbContext>
    {
        protected override void Seed(InventoryDbContext context)
        {
            var inventories = new List<Models.Inventory>
            {
                new Models.Inventory{ ID = 1, Quantity = 12},
                new Models.Inventory{ ID = 2, Quantity = 10},
                new Models.Inventory{ ID = 3, Quantity = 15},
                new Models.Inventory{ ID = 4, Quantity = 20},
                new Models.Inventory{ ID = 5, Quantity = 22},
                new Models.Inventory{ ID = 6, Quantity = 25},
            };

            context.Inventories.AddRange(inventories);
            context.SaveChanges();
        }

    }
}