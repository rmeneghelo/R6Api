using Microsoft.Extensions.Options;
using R6Api.Domain.Interfaces.Respositories;
using R6Api.Domain.Models.Entities;
using R6Api.Domain.Options;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;

namespace R6Api.Repository.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IOptions<HeaderOption> _headerOption;
        private readonly IOptions<UbisoftOption> _ubisoftOption;

        public AuthenticationRepository(IOptions<HeaderOption> headerOption, IOptions<UbisoftOption> ubisoftOption)
        {
            _headerOption = headerOption;
            _ubisoftOption = ubisoftOption;
        }

        public async Task<AuthorizedUser> GetAuthenticatedUserAsync()
        {
            var client = new RestClient(_ubisoftOption.Value.AuthorizationUrl);
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", _headerOption.Value.ContentType);
            request.AddHeader("Ubi-AppId", _ubisoftOption.Value.UbiAppId);
            request.AddHeader("Authorization", _ubisoftOption.Value.AuthorizationHeader);

            var handle = await client.ExecuteTaskAsync<AuthorizedUser>(request, new CancellationToken()).ConfigureAwait(false);

            return handle.Data;
        }
    }
}
