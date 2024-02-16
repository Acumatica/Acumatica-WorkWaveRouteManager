using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities
{
    [JsonObject(Description = "WorkWave Route")]
    public class WorkWaveRoute
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("revision")]
        public int Revision { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("vehicleId")]
        public string VehicleId { get; set; }
        [JsonProperty("driverId")]
        public string DriverId { get; set; }
        [JsonProperty("trackingData")]
        public Dictionary<string, object> TrackingData { get; set; }
        [JsonProperty("steps")]
        public List<WorkWaveRouteStep> Steps { get; set; }
    }

    [JsonObject(Description = "WorkWave Route Response")]
    public class WorkWaveRouteResponse : IWorkWaveEntitiesResponse<Dictionary<string, object>>
    {
        [JsonProperty("routes")]
        public Dictionary<string, object> Results { get; set; }
    }
}
