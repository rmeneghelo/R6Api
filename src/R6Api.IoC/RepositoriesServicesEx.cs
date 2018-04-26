using Microsoft.Extensions.DependencyInjection;
using R6Api.Domain.Interfaces.Respositories;
using R6Api.Repository;

namespace R6Api.IoC
{
    public static class RepositoriesServicesEx
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IStatisticsRepository, StatisticsRepository>();
        }
    }
}
