using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain.Vehicles
{
    class TimeWindow
    {
        [JsonProperty("startSec")]
        public int StartSec { get; set; }
        [JsonProperty("endSec")]
        public int EndSec { get; set; }
    }
}
