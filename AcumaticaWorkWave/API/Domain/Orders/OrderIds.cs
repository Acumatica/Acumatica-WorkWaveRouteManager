using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Orders
{
    public class OrderIds
    {
        public OrderIds()
        {
            Ids = new List<Guid?>();
        }
        
        [JsonProperty("ids")]
        public List<Guid?> Ids { get; set; }
    }
}