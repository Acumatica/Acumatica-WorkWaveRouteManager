using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities
{
    [JsonObject(Description = "WorkWave Route Step")]
    public class WorkWaveRouteStep
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("orderId")]
        public string OrderId { get; set; }
        [JsonProperty("idleTimeSec")]
        public double IdleTimeSec { get; set; }
        [JsonProperty("perStopTimeSec")]
        public double PerStopTimeSec { get; set; }
        [JsonProperty("arrivalSec")]
        public double ArrivalSec { get; set; }
        [JsonProperty("startSec")]
        public double StartSec { get; set; }
        [JsonProperty("endSec")]
        public double EndSec { get; set; }
        [JsonProperty("driveToNextSec")]
        public double DriveToNextSec { get; set; }
        [JsonProperty("stopIdx")]
        public int StopIdx { get; set; }
        [JsonProperty("displayLabel")]
        public string DisplayLabel { get; set; }
    }
}
