using Store.Services.HandelResponse;
using System.Net;
using System.Text.Json;

namespace Store.Web.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                // Production ==> Log Database
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Handling Response based on Environment type
                var responseEnv = _env.IsDevelopment() ? new CustomException(500, ex.Message, ex.StackTrace.ToString()) :
                    new CustomException((int)HttpStatusCode.InternalServerError);

                var Options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var jsonResponse = JsonSerializer.Serialize(responseEnv, Options);
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
