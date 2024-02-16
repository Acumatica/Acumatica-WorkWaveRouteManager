using AcumaticaWorkWave.API.Domain.Depots;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Orders
{
    public class OrderHash
    {
        [JsonProperty("orders")]
        public Dictionary<Guid, Order> Orders { get; set; }

        [JsonProperty("depots")]
        public Dictionary<Guid, Depot> Depots { get; set; }

        public OrderHash WithOrders()
        {
            Orders = new Dictionary<Guid, Order>();
            return this;
        }

        public OrderHash WithDepots()
        {
            Depots = new Dictionary<Guid, Depot>();
            return this;
        }
    }
}