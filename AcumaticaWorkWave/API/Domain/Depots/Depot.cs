using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain.Depots
{
    public class Depot
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("setupCost")]
        public int SetupCost { get; set; }

        [JsonProperty("setupTimeSec")]
        public int SetupTimeSec { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}