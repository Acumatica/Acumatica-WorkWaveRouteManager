using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Orders
{
    public class Location
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("latLng")]
        public List<int> LatLng { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        public Location WithLatLng()
        {
            LatLng = new List<int>();
            return this;
        }
    }
}