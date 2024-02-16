using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities
{
    [JsonObject(Description = "WorkWave Order")]
    public class WorkWaveOrder
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("eligibility")]
        public Dictionary<string, string> Eligibility { get; set; }
        [JsonProperty("forceVehicleId")]
        public string ForceVehicleId { get; set; }
        [JsonProperty("priority")]
        public string Priority { get; set; }
        [JsonProperty("pickup")]
        public WorkWaveOrderPickUpDelivery Pickup { get; set; }
        [JsonProperty("delivery")]
        public WorkWaveOrderPickUpDelivery Delivery { get; set; }
    }

    [JsonObject(Description = "WorkWave Order Response")]
    public class WorkWaveOrderResponse : IWorkWaveEntitiesResponse<Dictionary<string, object>>
    {
        [JsonProperty("orders")] 
        public Dictionary<string, object> Results { get; set; }
    }
}
