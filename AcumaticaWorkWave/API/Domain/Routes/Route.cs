using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    class Route
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("revision")]
        public int Revision { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("vehicleId")]
        public string VehicleId { get; set; }
        [JsonProperty("driverId")]
        public string DriverId { get; set; }
        [JsonProperty("vehicleViolations")]
        public List<string> VehicleViolations { get; set; }
        [JsonProperty("steps")]
        public List<Step> Steps { get; set; }
        [JsonProperty("trackingData")]
        public TrackingDataRegistry TrackingData { get; set; }
    }
}
