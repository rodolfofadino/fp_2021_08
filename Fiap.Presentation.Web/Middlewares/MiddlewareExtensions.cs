using Fiap.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Fiap.Presentation.Web.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMeuMiddlewareFiap(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MeuMiddleware>();
        }

    }
}