using MediatR;

namespace R6Api.Application.Responses
{
    public class UserStatisticsResponse : IRequest
    {
        public string Kills { get; set; }
    }
}
