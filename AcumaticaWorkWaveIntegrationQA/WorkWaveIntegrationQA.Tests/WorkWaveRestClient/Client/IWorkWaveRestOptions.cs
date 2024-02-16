using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client
{
    public interface IWorkWaveRestOptions
    {
        string baseUrl { get; }
        string apiKey { get; set; }
        string territoryId { get; set; }
    }
}
