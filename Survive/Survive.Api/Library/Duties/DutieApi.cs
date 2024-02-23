using Survive.Api.Api.Core;
using Survive.Api.Database;
using Survive.Api.Library.Products.Entities;

namespace Survive.Api.Library.Duties
{
    public static class DutieApi
    {
        public static void Register(WebApplication app, WebApplicationBuilder builder)
        {
            const string name = "dutie";
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
