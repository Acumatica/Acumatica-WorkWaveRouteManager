using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.Entity
{
    public class Carrier
    {
        public string CarrierId { get; set; }
        public string Description { get; set; }
        public string PlugInType { get; set; }
        public string CarrierUnits { get; set; }
        public string Kilogram { get; set; }
        public string Centimeter { get; set; }
        public string Warehouse { get; set; }
        public List<CarrierPlugInParameter<dynamic>> PlugInParameters { get; set; }
        public List<CarrierWorkWaveTerritory> CarrierWorkWaveTerritories { get; set; }
        public List<CarrierWorkWaveCustomFieldMapping> CarrierWorkWaveCustomFieldMappingList { get; set; }
    }
}
