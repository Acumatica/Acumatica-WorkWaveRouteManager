using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    class Current
    {
        [JsonProperty("departure")]
        public Time Departure { get; set; }
        [JsonProperty("arrival")]
        public Time Arrival { get; set; }
    }
}
