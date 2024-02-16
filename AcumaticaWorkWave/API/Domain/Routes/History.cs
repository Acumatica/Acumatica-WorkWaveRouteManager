using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    class History
    {
        [JsonProperty("eventType")]
        public string EventType { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("fix")]
        public Time Fix { get; set; }
    }
}
