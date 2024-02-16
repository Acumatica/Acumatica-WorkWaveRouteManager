using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    class HistoryList
    {
        [JsonProperty("history")]
        public List<History> History { get; set; }
    }
}
