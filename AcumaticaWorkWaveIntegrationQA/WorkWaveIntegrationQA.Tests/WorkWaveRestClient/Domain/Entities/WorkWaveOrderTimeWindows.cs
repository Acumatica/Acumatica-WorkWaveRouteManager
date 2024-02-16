using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities
{
    [JsonObject(Description = "WorkWave Order Time Windows")]
    public class WorkWaveOrderTimeWindows
    {
        [JsonProperty("startSec")]
        public int StartSec { get; set; }
        [JsonProperty("endSec")]
        public int EndSec { get; set; }
    }
}
