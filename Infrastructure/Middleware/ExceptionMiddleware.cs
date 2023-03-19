using System.Net;
using System.Text.Json;
using ClientSelfService.Infrastructure.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClientSelfService.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        private const string _internalError = "Internal Server Error";
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
            IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ProcessOnError(context, ex);
            }
        }

        private async Task ProcessOnError(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, string.Format("Message: {0}; StackTrace : {1};", ex.Message, ex.StackTrace?.ToString()));

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = ErrorResponse(context, ex);
            var json = JsonResult(response);

            await context.Response.WriteAsync(json);
        }

        private string JsonResult(ApiException response)
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);
            return json;
        }

        private ApiException ErrorResponse(HttpContext context, Exception ex)
        {
            return _env.IsDevelopment() ? DevelopmentException(context, ex) : ProductionException(context, ex);
        }

        private ApiException DevelopmentException(HttpContext context, Exception ex)
        {
            var stackTrace = ex.StackTrace ?? string.Empty;
            return new ApiException(context.Response.StatusCode, ex.Message, stackTrace.ToString());
        }

        private ApiException ProductionException(HttpContext context, Exception ex)
        {
            return new ApiException(context.Response.StatusCode, _internalError);
        }
    }
}