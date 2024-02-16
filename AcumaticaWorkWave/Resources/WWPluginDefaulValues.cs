using PX.Common;
using PX.Data.BQL;

namespace AcumaticaWorkWave.Resources
{
    [PXLocalizable]
    public class WWPluginDefaulValues
    {
        public const string URL = "wwrm.workwave.com";
        public const string WWRM_ELIGIBILITY_TYPE = "by";
        public static string DEFAULT_WWRM_ROUTE_TYPE = WWPluginProperties.WWRM_ROUTE_PICK_UP_DROP_OFF;
        public const string PLUGIN_ASSEMBLY_NAME = "AcumaticaWorkWave.Plugin.WorkWaveCarrier";
        public const string PLUGIN_TYPE_NAME = "Plug-In (Type)";
        public class pluginAssemblyName : BqlType<IBqlString, string>.Constant<pluginAssemblyName>
        {
            public pluginAssemblyName() : base(PLUGIN_ASSEMBLY_NAME) { }
        }
    }
}