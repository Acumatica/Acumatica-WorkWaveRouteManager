using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.WebhookRestClient.Domain.Entities
{
    public interface IWebhookEntitiesResponse<T>
    {
        int Count { get; set; }
        List<T> Results { get; set; }
    }
}
