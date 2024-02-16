using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities
{
    public interface IWorkWaveEntitiesResponse<T>
    {
        T Results { get; set; }
    }
}
