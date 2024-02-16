using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Vehicles
{
    class VehicleSettings
    {
        [JsonProperty("available")]
        public bool Available { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("departureDepotId")]
        public Guid DepartureDepotId { get; set; }
        [JsonProperty("arrivalDepotId")]
        public Guid ArrivalDepotId { get; set; }
        [JsonProperty("timeWindow")]
        public TimeWindow TimeWindow { get; set; }
        [JsonProperty("flexStartTime")]
        public bool FlexStartTime { get; set; }
        [JsonProperty("perStopCost")]
        public int PerStopCost { get; set; }
        [JsonProperty("perStopTimeSec")]
        public int PerStopTimeSec { get; set; }
        [JsonProperty("maxWorkingTimeSec")]
        public int MaxWorkingTimeSec { get; set; }
        [JsonProperty("maxDrivingTimeSec")]
        public int MaxDrivingTimeSec { get; set; }
        [JsonProperty("maxDistanceMt")]
        public int MaxDistanceMt { get; set; }
        [JsonProperty("maxOrders")]
        public int MaxOrders { get; set; }
        [JsonProperty("breaks")]
        public List<Break> Breaks { get; set; }
        [JsonProperty("loadCapacities")]
        public object LoadCapacities { get; set; }
        [JsonProperty("regionIds")]
        public List<Guid> RegionIds { get; set; }
        [JsonProperty("activationCost")]
        public int ActivationCost { get; set; }
        [JsonProperty("drivingTimeCost")]
        public int DrivingTimeCost { get; set; }
        [JsonProperty("idleTimeCost")]
        public int IdleTimeCost { get; set; }
        [JsonProperty("serviceTimeCost")]
        public int ServiceTimeCost { get; set; }
        [JsonProperty("breakTimeCost")]
        public int BreakTimeCost { get; set; }
        [JsonProperty("kmCost")]
        public int KmCost { get; set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
        [JsonProperty("speedFactor")]
        public int SpeedFactor { get; set; }
        [JsonProperty("minWorkingTimeSec")]
        public int MinWorkingTimeSec { get; set; }
        [JsonProperty("minLoadCapacities")]
        public object MinLoadCapacities { get; set; }
    }
}
