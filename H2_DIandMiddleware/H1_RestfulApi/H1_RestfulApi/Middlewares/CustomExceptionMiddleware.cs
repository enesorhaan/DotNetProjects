using H1_RestfulApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace H1_RestfulApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService logger)
        {
            _next = next;
            _logger = logger; // Dependency Injection define
        }

        public async Task Invoke(HttpContext context)
        {
            string message = $"[Request] {context.Request.Method} - {context.Request.Path}";
            _logger.Write(message); // Dependency Injection Using
            await _next(context);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
