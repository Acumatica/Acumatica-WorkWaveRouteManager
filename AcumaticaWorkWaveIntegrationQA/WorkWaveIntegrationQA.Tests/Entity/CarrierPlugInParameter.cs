using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.Entity
{
    public class CarrierPlugInParameter<T>
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public T Value { get; set; }
    }
}
