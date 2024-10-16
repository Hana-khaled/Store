using Microsoft.Extensions.Logging;
using Store.Data.Contexts;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.ProductTypes != null && !context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Store.Repository/SeedData/types.json");

                    // serilization: Object -> string (to store it in a file)
                    // deserilization: string -> object (Must be the same structure of the table)
                    // done through JsonSerializer

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    if (types != null)
                    {
                        await context.ProductTypes.AddRangeAsync(types);
                    }
                }

                if (context.ProductBrands != null && !context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Store.Repository/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    if (brands != null)
                    {
                        await context.ProductBrands.AddRangeAsync(brands);
                    }
                }

                if (context.Products != null && !context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Store.Repository/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    if (products != null)
                    {
                        await context.Products.AddRangeAsync(products);
                    }
                }

                context.SaveChanges();

            }

            catch (Exception ex) 
            {
                var logger = loggerFactory.CreateLogger<StoreDbContext>();
                logger.LogError(ex.Message);

            }
        }
    }
}
