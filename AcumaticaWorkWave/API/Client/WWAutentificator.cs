using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace AcumaticaWorkWave.API.Client
{
    public class WWAutentificator : IAuthenticator
    {
        private readonly IWWRestOptions _options;

        public WWAutentificator(IWWRestOptions options)
        {
            _options = options;
        }

        // public void Authenticate(IRestClient client, IRestRequest request)
        // {
        //     request.AddHeader("Accept", "application/json");
        //     request.AddHeader("Content-Type", "application/json");
        //     request.AddHeader("X-WorkWave-Key", _options.ApiKey.ToString());
        // }

        public ValueTask Authenticate(RestClient client, RestRequest request)
        {
            if (request.Parameters.All(x => x.Name != "X-WorkWave-Key"))
            {
                request.AddHeader("X-WorkWave-Key", _options.ApiKey.ToString());
            }
            
            return default;
        }
    }
}
