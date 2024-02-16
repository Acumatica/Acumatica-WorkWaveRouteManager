using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.Entity
{
    public class ReportParameter
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string ShipmentNbr { get; set; }
        public string CustomerId { get; set; }
        public string Warehouse { get; set; }
        public string InventoryId { get; set; }
        public bool DriverNotes { get; set; }
        public bool GPS { get; set; }
        public bool Signature { get; set; } 
        public bool Picture { get; set; }
        public bool Packages { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (System.Reflection.PropertyInfo property in this.GetType().GetProperties())
            {
                if (property.GetValue(this, null) != null)
                {
                    sb.Append(property.Name);
                    sb.Append(": ");
                    if (property.GetIndexParameters().Length == 0)
                    {
                        sb.Append(property.GetValue(this, null));
                    }
                    sb.Append(", ");
                }
            }

            return sb.ToString(); ;
        }
    }
}
