using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Orders
{
    public class OrderList
    {
        public OrderList()
        {
            Orders = new List<Order>();
        }
        
        [JsonProperty("orders")]
        public List<Order> Orders { get; set; }
    }
}