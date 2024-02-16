using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Depots
{
    public class DepotsHash
    {
        [JsonProperty("depots")]
        public Dictionary<Guid, Depot> Depots { get; set; }
    }
}