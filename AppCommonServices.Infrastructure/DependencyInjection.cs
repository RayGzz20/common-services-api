using AppCommonServices.Application.Common.Interfaces;
using AppCommonServices.Domain.Common;
using AppCommonServices.Domain.Faq;
using AppCommonServices.Domain.Feedback;
using AppCommonServices.Infrastructure.Common.Persistence;
using AppCommonServices.Infrastructure.Faq;
using AppCommonServices.Infrastructure.Feedback;
using AppCommonServices.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppCommonServices.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DataBaseSql")));

            services.AddScoped<IApplicationDbContext>(sp =>
                    sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork>(sp =>
                    sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IFaqRepository, FaqRepository>();

            services.AddTransient<IDateTimeService, DateTimeService>();

            services.AddScoped<IFeedbackRepository, FeedbackRepository>();

            return services;
        }
    }
}
