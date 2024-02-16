using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Regions
{
    public class Region
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("poly")]
        public List<List<int>> Poly { get; set; }

        [JsonProperty("enterCost")]
        public int EnterCost { get; set; }

        [JsonProperty("enterTimeSec")]
        public int EnterTimeSec { get; set; }
    }
}