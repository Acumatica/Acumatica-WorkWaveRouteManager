using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.WebhookRestClient.Domain.Entities
{
    [JsonObject(Description = "Request Response")]
    public class WebhookRequestResponse : IWebhookEntitiesResponse<WebhookRequest>
    {
        [JsonProperty("total")]
        public int Count { get; set; }
        [JsonProperty("data")]
        public List<WebhookRequest> Results { get; set; }
    }

    [JsonObject(Description = "Request")]
    public class WebhookRequest
    {
        [JsonProperty("content")] 
        public string Content { get; set; }

        [JsonProperty("query")]
        public Dictionary<string,string> Query { get; set; }
    }
}
