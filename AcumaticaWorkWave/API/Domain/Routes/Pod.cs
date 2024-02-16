using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    public class Pod
    {
        [JsonProperty("sec")]
        public int Sec { get; set; }

        [JsonProperty("latLng")]
        public List<int> LatLng { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}