using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WorkWaveIntegrationQA.Tests.WebhookRestClient.Client;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client
{
    public class WorkWaveRestOptions : IWorkWaveRestOptions
    {
        [JsonIgnore]
        public string baseUrl { get; } = "https://wwrm.workwave.com";
        public string apiKey { get; set; }
        public string territoryId { get; set; }

        public WorkWaveRestOptions(string apiKey = "615b4b7b-c597-42bd-95d5-661f4e6408aa", string territoryId = "8c9be750-efe4-478d-ae0f-a134c761c1ac")
        {
            this.apiKey = apiKey;
            this.territoryId = territoryId;
        }
    }
}
