using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    public class Step
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("idleTimeSec")]
        public int IdleTimeSec { get; set; }
        [JsonProperty("perStopTimeSec")]
        public int PerStopTimeSec { get; set; }
        [JsonProperty("arrivalSec")]
        public int ArrivalSec { get; set; }
        [JsonProperty("startSec")]
        public int StartSec { get; set; }
        [JsonProperty("endSec")]
        public int EndSec { get; set; }
        [JsonProperty("driveToNextSec")]
        public int DriveToNextSec { get; set; }
        [JsonProperty("distanceToNextMt")]
        public int DistanceToNextMt { get; set; }
        [JsonProperty("stopIdx")]
        public int StopIdx { get; set; }
        [JsonProperty("displayLabel")]
        public string DisplayLabel { get; set; }
        [JsonProperty("orderId")]
        public Guid? OrderId { get; set; }
        [JsonProperty("violations")]
        public List<string> Violations { get; set; }
        [JsonProperty("trackingData")]
        public TrackingData TrackingData { get; set; }
        [JsonProperty("trackingLink")]
        public string TrackingLink { get; set; }
    }
}
