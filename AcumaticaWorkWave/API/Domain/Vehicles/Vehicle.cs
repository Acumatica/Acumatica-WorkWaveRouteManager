using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Vehicles
{
    class Vehicle
    {
        public Vehicle()
        {
            Settings = new Dictionary<string, VehicleSettings>();
        }

        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("idx")]
        public int Idx { get; set; }
        [JsonProperty("externalId")]
        public string ExternalId { get; set; }
        [JsonProperty("tracked")]
        public bool Tracked { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("gpsDeviceId")]
        public string gpsDeviceId { get; set; }
        [JsonProperty("settings")]
        public Dictionary<string, VehicleSettings> Settings { get; set; }
    }
}
