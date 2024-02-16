using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain.Orders
{
    public class Loads
    {
        [JsonProperty("frozenton")]
        public int Frozenton { get; set; }

        [JsonProperty("regularton")]
        public int Regularton { get; set; }

        [JsonProperty("people")]
        public int People { get; set; }
    }


}
