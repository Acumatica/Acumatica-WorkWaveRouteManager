using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain.Vehicles
{
    class Break
    {
        [JsonProperty("durationSec")]
        public int DurationSec { get; set; }
        [JsonProperty("startSec")]
        public int StartSec { get; set; }
        [JsonProperty("endSec")]
        public int EndSec { get; set; }
    }
}
