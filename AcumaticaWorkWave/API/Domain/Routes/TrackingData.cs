using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    public class TrackingData
    {
        [JsonProperty("driverId")]
        public Guid DriverId { get; set; }

        [JsonProperty("vehicleId")]
        public Guid VehicleId { get; set; }

        [JsonProperty("timeInSec")]
        public int TimeInSec { get; set; }

        [JsonProperty("timeInLatLng")]
        public List<int> TimeInLatLng { get; set; }

        [JsonProperty("timeOutSec")]
        public int TimeOutSec { get; set; }

        [JsonProperty("timeOutLatLng")]
        public List<int> TimeOutLatLng { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusSec")]
        public int? StatusSec { get; set; }

        [JsonProperty("statusLatLng")]
        public List<int> StatusLatLng { get; set; }

        [JsonProperty("statusReason")]
        public string StatusReason { get; set; }

        [JsonProperty("timeInDetectedSec")]
        public int TimeInDetectedSec { get; set; }

        [JsonProperty("timeInDetectedLatLng")]
        public List<int> TimeInDetectedLatLng { get; set; }

        [JsonProperty("timeOutDetectedSec")]
        public int TimeOutDetectedSec { get; set; }

        [JsonProperty("timeOutDetectedLatLng")]
        public List<int> TimeOutDetectedLatLng { get; set; }

        [JsonProperty("pods")]
        public PodContainer Pods { get; set; }
    }
}