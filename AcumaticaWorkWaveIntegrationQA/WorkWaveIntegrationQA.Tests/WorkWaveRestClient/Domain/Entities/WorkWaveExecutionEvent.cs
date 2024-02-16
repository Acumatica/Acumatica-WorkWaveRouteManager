using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities
{
    [JsonObject(Description = "WorkWave Execution Event")]
    public class WorkWaveExecutionEvent
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("orderId")]
        public string OrderId { get; set; }
        [JsonProperty("vehicleId")]
        public string VehicleId { get; set; }
        [JsonProperty("orderStepType")]
        public string OrderStepType { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("data")]
        public dynamic Data { get; set; }
    }
}
