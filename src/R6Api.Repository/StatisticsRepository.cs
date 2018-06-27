using Microsoft.Extensions.Options;
using R6Api.Domain.Interfaces.Respositories;
using R6Api.Domain.Options;
using RestSharp;
using System.Threading.Tasks;

namespace R6Api.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        IOptions<HeaderOption> _headerOption;
        IOptions<UbisoftOption> _ubisoftOption;

        public StatisticsRepository(IOptions<HeaderOption> headerOption, IOptions<UbisoftOption> ubisoftOption)
        {
            _headerOption = headerOption;
            _ubisoftOption = ubisoftOption;
        }

        public async void GetStatistics()
        {
            var client = new RestClient(_ubisoftOption.Value.AuthorizationUrl);
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", _headerOption.Value.ContentType);
            request.AddHeader("Ubi-AppId", _ubisoftOption.Value.UbiAppId);
            request.AddHeader("Authorization", _ubisoftOption.Value.AuthorizationHeader);

            var taskCompletion = new TaskCompletionSource<IRestResponse>();

            var handle = client.ExecuteAsync(
                request, r => taskCompletion.SetResult(r));

            RestResponse response = (RestResponse)(await taskCompletion.Task);
        }
    }
}
