using AppCommonServices.WebAPI.Common.Middlewares;

namespace AppCommonServices.WebAPI.Extensions
{
    public static class MiddlewareExtensions
    {

        public static IApplicationBuilder UseApiMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GloblalExceptionHandlingMiddleware>();
            app.UseMiddleware<HeaderUserIdMiddleware>();

            return app;
        }
    }
}
