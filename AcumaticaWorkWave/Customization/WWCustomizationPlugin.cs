using AcumaticaWorkWave.BLC;
using Customization;
using PX.Data;
using PX.Objects.SO;

namespace AcumaticaWorkWave.Customization
{
    public class WWCustomizationPlugin : CustomizationPlugin
    {
        public override void UpdateDatabase()
        {
            WriteLog("Update SOShipment condition fields");
            var graph = PXGraph.CreateInstance<SOShipmentEntry>().GetExtension<WWSOShipmentEntryExt>();
            graph.UpdateSOShipmentConditions();
        }
    }
}