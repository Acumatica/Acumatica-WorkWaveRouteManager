using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Regions
{
    public class RegionHash
    {
        [JsonProperty("regions")]
        public Dictionary<string, Region> Regions { get; set; }
    }
}