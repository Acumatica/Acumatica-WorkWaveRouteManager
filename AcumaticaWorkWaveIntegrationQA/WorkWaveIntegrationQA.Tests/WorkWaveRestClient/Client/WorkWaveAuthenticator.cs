using RestSharp;
using RestSharp.Authenticators;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client
{
    public class WorkWaveAuthenticator : IAuthenticator
    {
        private readonly string xWorkWaveKey;

        public WorkWaveAuthenticator(string sessionId)
        {
            xWorkWaveKey = sessionId;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddHeader("X-WorkWave-Key", xWorkWaveKey);
        }
    }
}
