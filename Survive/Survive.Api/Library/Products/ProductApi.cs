using Survive.Api.Database;
using Survive.Api.Library.Products.Entities;

namespace Survive.Api.Library.Products
{
    public static class ProductApi
    {
        public static void Register(WebApplication app, WebApplicationBuilder builder)
        {
            var api = app.MapGroup("product").RequireAuthorization();

            api.MapPost("/", async (MainDbContext db) =>
            {
                var product = new Product("sample", "sample");
                await db.Products.AddAsync(product);

                await db.SaveChangesAsync();

                return Results.Created($"/product/{product.Id}", product);
            });

        }
    }

}
