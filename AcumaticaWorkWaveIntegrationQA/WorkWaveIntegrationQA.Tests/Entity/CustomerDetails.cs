using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.Entity
{
    public class CustomerDetails
    {
        public string CustomerId { get; set; }
        public string Status { get; set; }
        public string CustomerClass { get; set; }
        public string AccountName { get; set; }
        public string AccountEmail { get; set; }
        public AddressDetail AccountAddress { get; set; }
        public string TimeWindowStart { get; set; }
        public string TimeWindowEnd { get; set; }
        public override string ToString()
        {
            return $"Customer Details: CustomerId: {CustomerId}, Status: {Status}, CustomerClass: {CustomerClass}, AccountName: {AccountName}, " +
                   $"TimeWindowStart: {TimeWindowStart}, TimeWindowEnd: {TimeWindowEnd}";
        }
    }
}
