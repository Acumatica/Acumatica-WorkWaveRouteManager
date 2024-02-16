using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Territories
{
    public class TerritoryHash
    {
        [JsonProperty("territories")]
        public Dictionary<Guid, Territory> Territories { get; set; }
    }
}