using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain
{
    public class WWAsyncResponseData
    {
        [JsonProperty("created")]
        public List<WWChangedOrder> Created { get; set; }

        [JsonProperty("updated")]
        public List<WWChangedOrder> Updated { get; set; }

        [JsonProperty("deleted")]
        public List<Guid> Deleted { get; set; }
    }
}