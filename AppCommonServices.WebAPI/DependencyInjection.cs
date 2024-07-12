using AppCommonServices.Application.Common.Interfaces;
using AppCommonServices.WebAPI.Common.Middlewares;
using AppCommonServices.WebAPI.Extensions;
using AppCommonServices.WebAPI.Services;

namespace AppCommonServices.WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddTransient<GloblalExceptionHandlingMiddleware>();
            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();            

            return services;
        }

        public static IServiceCollection AddAndConfigServicesPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAndConfigApiVersioning();
            services.AddAndConfigSwagger();
            services.AddAndConfigAuthentication(configuration);
            services.AddAndConfigTelemetry(configuration);

            return services;
        }
    }
}
