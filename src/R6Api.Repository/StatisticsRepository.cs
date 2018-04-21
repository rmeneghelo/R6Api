using Microsoft.Extensions.Configuration;
using R6Api.Domain.Interfaces.Respositories;
using RestSharp;
using System.Threading.Tasks;

namespace R6Api.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        IConfiguration _configuration;

        public StatisticsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async void GetStatistics()
        {
            var client = new RestClient(_configuration["AuthorizationUrl"]);
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Ubi-AppId", _configuration["Ubisoft:UbiAppId"]);
            request.AddHeader("Authorization", _configuration["Ubisoft:AuthorizationHeader"]);

            var taskCompletion = new TaskCompletionSource<IRestResponse>();

            var handle = client.ExecuteAsync(
                request, r => taskCompletion.SetResult(r));

            RestResponse response = (RestResponse)(await taskCompletion.Task);
        }
    }
}
