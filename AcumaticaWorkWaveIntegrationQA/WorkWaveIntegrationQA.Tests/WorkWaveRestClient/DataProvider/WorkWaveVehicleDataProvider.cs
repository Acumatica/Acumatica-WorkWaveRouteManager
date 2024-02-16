using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.DataProvider
{
    public class WorkWaveVehicleDataProvider : WorkWaveBaseDataProvider
    {
        protected override string GetListUrl => "/api/v1/territories/{territoryId}/vehicles";
        protected override string SingleOrderUrl => "";
        protected override string PostUpdateWWOrderUrl => "";
        public WorkWaveVehicleDataProvider(IWorkWaveRestOptions options) : base(options) { }
        public WorkWaveVehicleResponse GetAll(string territoryId)
        {
            WorkWaveUrlSegments segments = new WorkWaveUrlSegments();
            segments.AddTerritoryId(territoryId);
            return Get<Dictionary<string, object>, WorkWaveVehicleResponse>(GetListUrl, segments);
        }
    }

    public class WorkWaveVehicleDataHelper
    {
        private readonly IWorkWaveRestOptions _options;

        public WorkWaveVehicleDataHelper(IWorkWaveRestOptions options)
        {
            _options = options;
        }

        public WorkWaveVehicleResponse GetAll()
        {
            using (var dataProvider = new WorkWaveVehicleDataProvider(_options))
            {
                return dataProvider.GetAll(_options.territoryId);
            }
        }

        public List<WorkWaveVehicle> GetVehicleList()
        {
            using (var dataProvider = new WorkWaveVehicleDataProvider(_options))
            {
                var response = dataProvider.GetAll(_options.territoryId);
                var tempDictionary = response.Results;
                List<WorkWaveVehicle> resultList = new List<WorkWaveVehicle>();
                foreach (var pair in tempDictionary)
                {
                    var json = JsonConvert.SerializeObject(pair.Value);
                    var tempVehicle = JsonConvert.DeserializeObject<WorkWaveVehicle>(json);
                    resultList.Add(tempVehicle);
                }
                return resultList;
            }
        }

        public string GetIdByExternalId(string externalId = "Vehicle 1")
        {
            var vehicleList = GetVehicleList();
            var foundVehicle = vehicleList.FirstOrDefault(r => r.ExternalId.Equals(externalId));
            if (foundVehicle == null)
                throw new Exception($"Vehicle is not found by externalId: {externalId}");
            return foundVehicle.Id;
        }
    }
}
