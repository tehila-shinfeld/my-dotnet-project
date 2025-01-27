namespace Swim.Api
{
    public static class ShabbatMiddlewareExtensions
    {

        public static IApplicationBuilder UseShabbat(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShabbatMiddleware>();
        }

    }
}
