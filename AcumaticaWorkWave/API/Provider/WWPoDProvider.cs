using AcumaticaWorkWave.API.Client;
using RestSharp;

namespace AcumaticaWorkWave.API.Provider
{
    public class WWPoDProvider : WWBaseProvider
    {
        private const string TOKEN_ID = "token";
        private readonly string podUrl = $"/api/v1/pod/{LB}{TOKEN_ID}{RB}";

        public WWPoDProvider(IWWRestOptions options) : base(options)
        {
        }

        public byte[] GetPoD(string token)
        {
            var segments = GetTokenSegment(token);
            var res = Get(podUrl, segments);
            return res.RawBytes;
        }

        private static WWUrlSegments GetTokenSegment(string token)
        {
            var segments = new WWUrlSegments();
            segments.Add(TOKEN_ID, token);
            return segments;
        }
    }
}