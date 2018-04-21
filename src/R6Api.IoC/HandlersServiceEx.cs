using Microsoft.Extensions.DependencyInjection;
using MediatR;
using R6Api.Application.Handlers;

namespace R6Api.IoC
{
    public static class HandlersServiceEx
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(UserStatisticsHandler).Assembly);
        }
    }
}
