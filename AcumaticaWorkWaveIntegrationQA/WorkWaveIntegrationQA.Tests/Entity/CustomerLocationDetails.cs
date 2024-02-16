using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.Entity
{
    public class CustomerLocationDetails
    {
        public string LocationId { get; set; }
        public string CustomerId { get; set; }
        public string LocationName { get; set; }
        public string TimeWindowStart { get; set; }
        public string TimeWindowEnd { get; set; }
    }
}
