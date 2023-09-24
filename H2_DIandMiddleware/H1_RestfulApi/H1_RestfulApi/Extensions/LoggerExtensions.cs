using H1_RestfulApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace H1_RestfulApi.Extensions
{
    public static class LoggerExtensions
    {
        public static IServiceCollection AddLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, ConsoleLogger>();
            return services;
        }
    }
}
