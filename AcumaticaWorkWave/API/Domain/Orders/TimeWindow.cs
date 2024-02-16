using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain.Orders
{
    public class TimeWindow
    {
        [JsonProperty("startSec")]
        public int StartSec { get; set; }

        [JsonProperty("endSec")]
        public int EndSec { get; set; }
    }


}
