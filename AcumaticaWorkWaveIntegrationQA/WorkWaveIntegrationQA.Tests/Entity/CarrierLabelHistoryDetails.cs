using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.Entity
{
    public class CarrierLabelHistoryDetails
    {
        public int CompanyID { get; set; }
        public int RecordID { get; set; }
        public string ShipmentNbr { get; set; }
        public int LineNbr { get; set; }
        public string PluginTypeName { get; set; }
        public string ServiceMethod { get; set; }
        public decimal RateAmount { get; set; }
        public Guid CreatedByID { get; set; }
        public string CreatedByScreenID { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string UsrCarrier { get; set; }

        public override string ToString()
        {
            return $"Carrier Label History Details: CompanyID: {CompanyID}, RecordID: {RecordID}, ShipmentNbr: {ShipmentNbr}, LineNbr: {LineNbr}, " +
                   $"PluginTypeName: {PluginTypeName}, ServiceMethod: {ServiceMethod}, RateAmount: {RateAmount}, CreatedByID: {CreatedByID}, " +
                   $"CreatedByScreenID: {CreatedByScreenID}, CreatedDateTime: {CreatedDateTime}, UsrCarrier: {UsrCarrier}";
        }
    }
}
