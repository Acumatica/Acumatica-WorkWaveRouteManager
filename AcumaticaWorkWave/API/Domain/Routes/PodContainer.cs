using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    public class PodContainer
    {
        [JsonProperty("barcodes")]
        public List<BarcodePod> Pods { get; set; }

        [JsonProperty("note")]
        public Pod Note { get; set; }

        [JsonProperty("pictures")]
        public Dictionary<string, Pod> Pictures { get; set; }

        [JsonProperty("signatures")]
        public Dictionary<string, Pod> Signatures { get; set; }
    }
}
