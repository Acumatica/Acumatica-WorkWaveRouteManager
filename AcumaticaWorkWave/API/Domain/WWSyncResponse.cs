using Newtonsoft.Json;
using System;

namespace AcumaticaWorkWave.API.Domain
{
    public class WWSyncResponse
    {
        [JsonProperty("requestId")]
        public Guid? RequestId { get; set; }

        [JsonIgnore]
        public Guid? EntityID { get; set; }

    }
}