using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Persistence.Context
{
    public class ApplicationDbContextSeed
    {

        //TODO: @ApplicationDbContextSeed SeedDefaultUserAsync
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                //context.Products.Add(new Product
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Keyboard",
                //    UnitPrice = 170.5,
                //    QuantityPerUnit = 1,
                //    UnitsInStock = 8
                //});
                //context.Products.Add(new Product
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Mouse",
                //    UnitPrice = 90.2,
                //    QuantityPerUnit = 1,
                //    UnitsInStock = 2
                //});
                //context.Products.Add(new Product
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Chair",
                //    UnitPrice = 100.8,
                //    QuantityPerUnit = 1,
                //    UnitsInStock = 1
                //});
                //context.Products.Add(new Product
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Monitor",
                //    UnitPrice = 300.0,
                //    QuantityPerUnit = 1,
                //    UnitsInStock = 1
                //});
                //context.Products.Add(new Product
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Socks",
                //    UnitPrice = 10.0,
                //    QuantityPerUnit = 2,
                //    UnitsInStock = 44
                //});

                await context.SaveChangesAsync();
            }
        }
    }
}
