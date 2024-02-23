using Survive.Api.Api.Core;
using Survive.Api.Database;
using Survive.Api.Library.Products.Entities;

namespace Survive.Api.Library.Places
{
    public static class PlaceApi
    {
        public static void Register(WebApplication app, WebApplicationBuilder builder)
        {
            const string name = "place";
            RouteGroupBuilder api = BaseApi.RegisterBase(app, name);

            api.MapPost(
                "/",
                async (MainDbContext db) =>
                {
                    var product = new Product("sample", "sample");
                    await db.Products.AddAsync(product);

                    await db.SaveChangesAsync();

                    return Results.Created($"/{name}/{product.Id}", product);
                }
            );
        }
    }
}
