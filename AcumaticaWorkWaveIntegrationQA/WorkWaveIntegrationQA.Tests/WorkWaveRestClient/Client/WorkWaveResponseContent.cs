using System.Collections.Generic;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client
{
    public class WorkWaveResponseError
    {
        [JsonProperty("errorCode")]
        public int Code { get; set; }

        [JsonProperty("errorMessage")]
        public string Message { get; set; }
    }
}
