using AcumaticaWorkWave.API.Client;
using AcumaticaWorkWave.API.Domain.Routes;
using RestSharp;

namespace AcumaticaWorkWave.API.Provider
{
    class WWRouteProvider : WWBaseProvider
    {
        private const string TERRITORY_ID = "territoryId";
        private readonly string listUrl = $"/api/v1/territories/{LB}{TERRITORY_ID}{RB}/toa/routes";

        public WWRouteProvider(IWWRestOptions options) : base(options)
        {
        }

        public RestResponse List(string territoryId)
        {
            var segments = new WWUrlSegments();
            segments.Add(TERRITORY_ID, territoryId);
            return Get(listUrl, segments);
        }

        public RouteHash List<T>(string territoryId) where T : RouteHash
        {
            var segments = new WWUrlSegments();
            segments.Add(TERRITORY_ID, territoryId);
            return Get<RouteHash>(listUrl, segments);
        }
    }
}
