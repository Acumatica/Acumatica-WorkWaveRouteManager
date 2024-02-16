using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    class TrackingDataRegistry
    {
        [JsonProperty("driversTrackingData")]
        public Dictionary<Guid, DriversTrackingData> DriversTrackingData { get; set; }
    }
}
