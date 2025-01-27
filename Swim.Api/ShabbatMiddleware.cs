namespace Swim.Api
{
    public class ShabbatMiddleware(RequestDelegate next, ILogger<ShabbatMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ShabbatMiddleware> _logger = logger;
        //contex = חבילת ה request
        public async Task InvokeAsync(HttpContext context)
        {
            // בודקים אם היום שבת
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                _logger.LogInformation("שירות לא פעיל בשבת");

                // החזרת Response עם סטטוס 400 והודעה שהשירות לא פעיל
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("השירות אינו פעיל בשבת.");
            }
            else
            {
                //אם לא שבת, ממשיכים הלאה ב-Pipeline
                await _next(context);
                //מכאן והלאה אסור לגעת או לשנות את הריספונס
            }
        }
    }
}
