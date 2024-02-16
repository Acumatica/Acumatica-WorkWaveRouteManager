using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.Entity
{
    public class ShipViaCode
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool ExternalPlugIn { get; set; }
        public string Calendar { get; set; }
        public string Carrier { get; set; }
        public string ServiceMethod { get; set; }
        public bool CommonCarrier { get; set; }
        public bool CalculateFreightOnReturns { get; set; }
        public bool ConfirmationForEachBoxIsRequired { get; set; }
        public bool AtLeastOnePackageIsRequired { get; set; }
        public bool GenerateReturnLabelAutomatically { get; set; }
        public string TaxCategory { get; set; }
        public string FreightSalesAccount { get; set; }
        public string FreightSalesSub { get; set; }
        public string FreightExpenseAccount { get; set; }
        public string FreightExpenseSub { get; set; }
    }
}
