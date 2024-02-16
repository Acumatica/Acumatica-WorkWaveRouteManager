using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Orders
{
    public class OrderInput
    {
        [JsonProperty("orders")]
        public List<Order> Orders { get; set; }

        [JsonProperty("strict")]
        public bool Strict { get; set; }

        [JsonProperty("acceptBadGeocodes")]
        public bool AcceptBadGeocodes { get; set; }

        public OrderInput WithOrders()
        {
            Orders = new List<Order>();
            return this;
        }
    }
}