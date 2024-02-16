using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities
{
    [JsonObject(Description = "WorkWave Execution Event Data")]
    public class WorkWaveExecutionEventData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("sec")]
        public double Sec { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("mime")]
        public string Mime { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
