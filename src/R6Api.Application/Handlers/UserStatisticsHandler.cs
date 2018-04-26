using MediatR;
using Microsoft.Extensions.Logging;
using R6Api.Application.Queries;
using R6Api.Application.Responses;
using R6Api.Domain.Interfaces.Respositories;
using System.Threading;
using System.Threading.Tasks;

namespace R6Api.Application.Handlers
{
    public class UserStatisticsHandler : IRequestHandler<UserStatisticsCommand, UserStatisticsResponse>
    {
        private readonly ILogger<UserStatisticsHandler> _logger;
        private readonly IStatisticsRepository _statisticsRepository;

        public UserStatisticsHandler(ILoggerFactory logger, IStatisticsRepository statisticsRepository)
        {
            _logger = logger.CreateLogger<UserStatisticsHandler>();
            _statisticsRepository = statisticsRepository;
        }

        public async Task<UserStatisticsResponse> Handle(UserStatisticsCommand request, CancellationToken cancellationToken)
        {
            _statisticsRepository.GetStatistics();
            return await Task.FromResult(new UserStatisticsResponse());
        }
    }
}
