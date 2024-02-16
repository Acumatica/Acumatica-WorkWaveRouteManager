using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities
{
    [JsonObject(Description = "WorkWave Order Location")]
    public class WorkWaveOrderLocation
    {
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("latLng")]
        public List<double> LatLng { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("geoAddress")]
        public string GeoAddress { get; set; }
    }
}
