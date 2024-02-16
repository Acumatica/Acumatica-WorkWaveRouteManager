using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities
{
    [JsonObject(Description = "WorkWave Order Pickup or Delivery")]
    public class WorkWaveOrderPickUpDelivery
    {
        [JsonProperty("depotId")]
        public string DepotId { get; set; }
        [JsonProperty("location")]
        public WorkWaveOrderLocation Location { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("serviceTimeSec")]
        public int ServiceTimeSec { get; set; }
        [JsonProperty("barcodes")]
        public List<string> Barcodes { get; set; }
        [JsonProperty("timeWindows")]
        public List<WorkWaveOrderTimeWindows> TimeWindows { get; set; }
    }
}
