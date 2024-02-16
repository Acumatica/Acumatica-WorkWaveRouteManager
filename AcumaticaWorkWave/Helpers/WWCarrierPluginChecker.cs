using AcumaticaWorkWave.Resources;
using Autofac;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.CS;

namespace AcumaticaWorkWave.Helpers
{
    public interface IWWCarrierPluginChecker
    {
        bool CheckIsWorkWavePluginType(PXGraph graph, string shipVia);
    }

    public class ServiceRegistrator : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WWCarrierPluginChecker>().As<IWWCarrierPluginChecker>();
        }
    }

    public class WWCarrierPluginChecker : IWWCarrierPluginChecker
    {
        public bool CheckIsWorkWavePluginType(PXGraph graph, string shipVia)
        {
            var carrierPluginByShipVia = new SelectFrom<CarrierPlugin>
                                       .InnerJoin<Carrier>.On<CarrierPlugin.carrierPluginID.IsEqual<Carrier.carrierPluginID>>
                                           .Where<Carrier.carrierID.IsEqual<@P.AsString>>.View(graph);

            var plugin = carrierPluginByShipVia.SelectSingle(shipVia);
            var isWorkWave = plugin?.PluginTypeName == WWPluginDefaulValues.PLUGIN_ASSEMBLY_NAME;
            return isWorkWave;
        }
    }
}