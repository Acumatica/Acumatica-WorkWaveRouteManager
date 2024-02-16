using AcumaticaWorkWave.API.Client;
using AcumaticaWorkWave.Plugin;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.DataProxy
{
    public class CarrierPluginDataProxy
    {
        public CarrierPluginDataProxy(WorkWaveCarrier service, WWRestOptions options, WWCarrierTerritory territory, List<WWCustomFieldMapping> mapping)
        {
            this.service = service;
            this.options = options;
            this.territory = territory;
            this.mapping = mapping;
        }

        public WorkWaveCarrier service { get; set; }
        public WWRestOptions options { get; set; }
        public WWCarrierTerritory territory { get; set; }
        public List<WWCustomFieldMapping> mapping { get; set; }
    }
}