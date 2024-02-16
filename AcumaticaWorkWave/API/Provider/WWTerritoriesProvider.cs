using AcumaticaWorkWave.API.Client;
using AcumaticaWorkWave.API.Domain.Territories;
using RestSharp;

namespace AcumaticaWorkWave.API.Provider
{
    public class WWTerritoriesProvider : WWBaseProvider
    {
        private const string listURL = "/api/v1/territories";        

        public WWTerritoriesProvider(IWWRestOptions options) : base(options)
        {
        }

        public RestResponse List()
        {
            return Get(listURL);
        }

        public TerritoryHash List<T>() where T: TerritoryHash
        {
            return Get<TerritoryHash>(listURL);
        }
    }
}