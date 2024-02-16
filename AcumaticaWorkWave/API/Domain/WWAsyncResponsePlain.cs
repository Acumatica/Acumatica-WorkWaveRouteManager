using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain
{
    public class WWAsyncResponsePlain
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("territoryId")]
        public string TerritoryId { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }
}