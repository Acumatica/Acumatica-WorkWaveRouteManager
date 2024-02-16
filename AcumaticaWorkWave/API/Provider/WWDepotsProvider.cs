using AcumaticaWorkWave.API.Client;
using AcumaticaWorkWave.API.Domain.Depots;
using RestSharp;

namespace AcumaticaWorkWave.API.Provider
{
    public class WWDepotsProvider : WWBaseProvider
    {
        private const string TERRITORY_ID = "territoryId";
        private readonly string listUrl = $"/api/v1/territories/{LB}{TERRITORY_ID}{RB}/depots";

        public WWDepotsProvider(IWWRestOptions options) : base(options)
        {
        }

        public RestResponse List(string territoryId)
        {
            var segments = new WWUrlSegments();
            segments.Add(TERRITORY_ID, territoryId);
            return Get(listUrl, segments);
        }

        public DepotsHash List<T>(string territoryId) where T : DepotsHash
        {
            var segments = new WWUrlSegments();
            segments.Add(TERRITORY_ID, territoryId);
            return Get<DepotsHash>(listUrl, segments);
        }
    }
}