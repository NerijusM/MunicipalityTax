using ClientSelfService.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Extensions;

public static class IApplicationBuilderExtensions
{
    public static IApplicationBuilder UseCustomAppLoging(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();

        return app;
    }
}
