using Newtonsoft.Json;


namespace WorkWaveIntegrationQA.Tests.WebhookRestClient.Client
{
    public class WebhookRestOptions : IWebhookRestOptions
    {
        [JsonIgnore]
        public string baseUrl { get; set; }
        public string token { get; set; }
        public string apiKey { get; set; }

        public WebhookRestOptions(string baseUrl = "https://webhook.site/token/", string token = "68dc8220-7b1d-4fbe-be56-7f163df8a65c", 
            string apiKey = "901abb25-53b4-429e-a2b0-c102806353c0")
        {
            this.baseUrl = baseUrl;
            this.token = token;
            this.apiKey = apiKey;
        }
    }
}
