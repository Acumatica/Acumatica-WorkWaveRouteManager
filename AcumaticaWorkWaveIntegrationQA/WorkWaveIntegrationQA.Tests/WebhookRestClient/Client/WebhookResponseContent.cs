using System.Collections.Generic;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.WebhookRestClient.Client
{
    public class WebhookResponseContent
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("errors")]
        public List<WebhookResponseError> Errors { get; set; }
    }

    public class WebhookResponseError
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
