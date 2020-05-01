namespace ApiExercise.Middlewares
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public RequestResponseLoggingMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.logger = loggerFactory
                      .CreateLogger<RequestResponseLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            this.logger.Log(LogLevel.Information, $"Method: {context.Request.Method} Path: {context.Request.Path}");

            await this.next(context);

            this.logger.Log(LogLevel.Information, $"Status code: {context.Response.StatusCode} Content-type: {context.Response.ContentType}");
        }
    }
}
