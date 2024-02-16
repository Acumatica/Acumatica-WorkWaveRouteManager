using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    class Time
    {
        [JsonProperty("sec")]
        public int Sec { get; set; }
        [JsonProperty("latLng")]
        public List<int> LatLng { get; set; }
    }
}
