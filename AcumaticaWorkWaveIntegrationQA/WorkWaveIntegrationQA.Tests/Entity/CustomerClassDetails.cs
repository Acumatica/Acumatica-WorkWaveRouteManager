using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace WorkWaveIntegrationQA.Tests.Entity
{
    public class CustomerClassDetails
    {
        public string ClassId { get; set; }
        public string Description { get; set; }
        public string TimeWindowStart { get; set; }
        public string TimeWindowEnd { get; set; }
        public override string ToString()
        {
            return $"Customer Class Details: ClassId: {ClassId}, Description: {Description}, TimeWindowStart: {TimeWindowStart}, " +
                   $"TimeWindowEnd: {TimeWindowEnd}";
        }
    }
}
