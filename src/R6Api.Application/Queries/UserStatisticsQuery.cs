using MediatR;
using R6Api.Application.Responses;

namespace R6Api.Application.Queries
{
    public class UserStatisticsQuery : IRequest<UserStatisticsResponse>
    {
        public string UserId { get; set; }
    }
}
