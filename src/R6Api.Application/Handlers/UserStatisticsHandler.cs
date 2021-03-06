﻿using MediatR;
using Microsoft.Extensions.Logging;
using R6Api.Application.Queries;
using R6Api.Application.Responses;
using R6Api.Domain.Interfaces.Respositories;
using System.Threading;
using System.Threading.Tasks;

namespace R6Api.Application.Handlers
{
    public class UserStatisticsHandler : IRequestHandler<UserStatisticsQuery, UserStatisticsResponse>
    {
        private readonly ILogger<UserStatisticsHandler> _logger;
        private readonly IStatisticsRepository _statisticsRepository;
        private readonly IAuthenticationRepository _authenticationRepository;

        public UserStatisticsHandler(
            ILoggerFactory logger, 
            IStatisticsRepository statisticsRepository,
            IAuthenticationRepository authenticationRepository)
        {
            _logger = logger.CreateLogger<UserStatisticsHandler>();
            _statisticsRepository = statisticsRepository;
            _authenticationRepository = authenticationRepository;
        }

        public async Task<UserStatisticsResponse> Handle(UserStatisticsQuery request, CancellationToken cancellationToken)
        {
            var authorizedUser = await _authenticationRepository.GetAuthenticatedUserAsync().ConfigureAwait(false);
            return await Task.FromResult(new UserStatisticsResponse());
        }
    }
}
