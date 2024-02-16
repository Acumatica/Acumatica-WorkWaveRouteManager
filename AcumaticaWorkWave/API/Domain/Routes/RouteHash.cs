using AcumaticaWorkWave.API.Domain.Depots;
using AcumaticaWorkWave.API.Domain.Drivers;
using AcumaticaWorkWave.API.Domain.Orders;
using AcumaticaWorkWave.API.Domain.Vehicles;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    class RouteHash
    {
        [JsonProperty("routes")]
        public Dictionary<string, Route> Routes { get; set; }
        [JsonProperty("orders")]
        public Dictionary<string, Order> Orders { get; set; }
        [JsonProperty("vehicles")]
        public Dictionary<string, Vehicle> Vehicles { get; set; }
        [JsonProperty("depots")]
        public Dictionary<string, Depot> Depots { get; set; }
        [JsonProperty("drivers")]
        public Dictionary<string, Driver> Drivers { get; set; }
    }
}
