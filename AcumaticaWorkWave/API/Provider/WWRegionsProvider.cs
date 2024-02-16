using AcumaticaWorkWave.API.Client;
using AcumaticaWorkWave.API.Domain.Regions;
using RestSharp;

namespace AcumaticaWorkWave.API.Provider
{
    public class WWRegionsProvider : WWBaseProvider
    {
        private const string listRegionsUrl = "/api/v1/territories";

        public WWRegionsProvider(IWWRestOptions options) : base(options)
        {
        }

        public RestResponse List()
        {
            return Get(listRegionsUrl);
        }

        public RegionHash List<T>() where T: RegionHash
        {
            return Get<RegionHash>(listRegionsUrl);
        }
    }
}