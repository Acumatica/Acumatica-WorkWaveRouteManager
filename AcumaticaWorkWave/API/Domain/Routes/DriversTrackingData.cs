using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    class DriversTrackingData
    {
        [JsonProperty("current")]
        public Current Current { get; set; }
        [JsonProperty("history")]
        public HistoryList History { get; set; }
    }
}
