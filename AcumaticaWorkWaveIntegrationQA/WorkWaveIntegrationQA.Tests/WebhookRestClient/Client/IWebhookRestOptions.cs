using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.WebhookRestClient.Client
{
    public interface IWebhookRestOptions
    {
        string baseUrl { get; set; }
        string token { get; set; }
        string apiKey { get; set; }
    }
}
