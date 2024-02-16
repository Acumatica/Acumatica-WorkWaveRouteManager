using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities
{
    [JsonObject(Description = "WorkWave Vehicle")]
    public class WorkWaveVehicle
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("idx")]
        public int Idx { get; set; }
        [JsonProperty("externalId")]
        public string ExternalId { get; set; }
        [JsonProperty("tracked")]
        public bool Tracked { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("gpsDeviceId")]
        public string GpsDeviceId { get; set; }
        [JsonProperty("settings")]
        public Dictionary<string, object> Settings { get; set; }
    }

    [JsonObject(Description = "WorkWave Vehicle Response")]
    public class WorkWaveVehicleResponse : IWorkWaveEntitiesResponse<Dictionary<string, object>>
    {
        [JsonProperty("vehicles")]
        public Dictionary<string, object> Results { get; set; }
    }
}
