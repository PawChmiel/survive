namespace Survive.Api.Api.Core
{
    public static class BaseApi
    {
        public static RouteGroupBuilder RegisterBase(WebApplication app, string name)
        {
            return app.MapGroup(name).RequireAuthorization();
        }
    }
}
